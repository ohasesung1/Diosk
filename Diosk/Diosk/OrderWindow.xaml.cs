using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Diosk.Core;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    /// 

    public class OrderArgs : EventArgs
    {
        public string tableId { get; set; }
    }

    public partial class OrderWindow : UserControl
    {
        public delegate void OrderCompleteHandler(Object sender, OrderArgs args);
        public event OrderCompleteHandler OnOrderComplete;

       

        private Core.Table currentTable;

        public OrderWindow()
        {
            InitializeComponent();
            this.Loaded += OrderWindow_Loaded;
        }
        private void OrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMenu("All");
        }

        private void LoadOrder()
        {
            lvOrder.Items.Clear();
            if (currentTable.FoodList != null)
            {
                foreach (Food food in currentTable.FoodList)
                {
                    lvOrder.Items.Add(food);
                }
            }
            lvOrder.Items.Refresh();
            SettingTable();
        }

        //현재 테이블을 세팅해주는 함수.
        public void SetTable(Core.Table table)
        {
            currentTable = table;
            LoadOrder();
        }

        //주문 메뉴의 +버튼 누를때 사용하는 함수.
        private void AddOrderCount(object sender, RoutedEventArgs e)
        {
            Button addBtn = (Button)sender;
            if (addBtn.DataContext is Food)
            {
                Food food = (Food)addBtn.DataContext;
                food.Count += 1;
            }

            lvOrder.Items.Refresh();
            SettingTable();
            SetOrderTime();
        }

        //주문 메뉴의 -버튼 누를때 사용하는 함수.
        private void SubtractOrderCount(object sender, RoutedEventArgs e)
        {
            Button subBtn = (Button)sender;
            if (subBtn.DataContext is Food)
            {
                Food food = (Food)subBtn.DataContext;
                food.Count -= 1;
                RemoveCheckFood(food);
            }

            lvOrder.Items.Refresh();
            SettingTable();
        }

        private void RemoveCheckFood(Food food)
        {
            if (food.Count <= 0)
            {
                lvOrder.Items.Remove(food);
            }
            else
            {
                SetOrderTime();
            }
        }

        //주문목록에 Food 추가하는 함수.
        private void AddOrderMenu(object sender, RoutedEventArgs e)
        {
            Food food = NewFood(((ListViewItem)sender).DataContext as Food);
            if (food == null) return;

            if (NameSearchFood(food) == null)
            {
                lvOrder.Items.Add(food);
            }

            NameSearchFood(food).Count++;
            lvOrder.Items.Refresh();
            SettingTable();
            SetOrderTime();
        }

        //Food의 이름으로 ListView에 Food를 찾아서 리턴하는 함수.
        private Food NameSearchFood(Food food)
        {
            Food item = lvOrder.Items.Cast<Food>().ToList<Food>().Find(x => x.Name == food.Name);
            if(item == null)
            {
                return null;
            }
            return item; 
        }

        //새로운 Food를 만드는 함수.
        private Food NewFood(Food item)
        {
            Food food = new Food();

            food.Name = item.Name;
            food.Price = item.Price;
            food.Count = item.Count;
            food.ImagePath = item.ImagePath;
            food.Category = item.Category;

            return food;
        }

        //테이블의 값을 세팅해주는 함수.
        private void SettingTable()
        {
            List<Food> list = lvOrder.Items.Cast<Food>().ToList<Food>();

            int tempPrice = 0;
            foreach (Food item in list)
            {
                tempPrice += item.Price * item.Count;
            }

            currentTable.FoodList = list;
            currentTable.TotalPrice = tempPrice;

            TbTotalPrice.Text = "총계 : " + currentTable.TotalPrice.ToString();
        }

        //테이블의 시간을 세팅해주는 함수.
        private void SetOrderTime()
        {
            currentTable.Time = DateTime.Now;
        }

        //클릭시 푸드 이미지 미리보기를 해주는 함수.
        private void FoodImgPreview(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;
            selectFoodImg.Source = image.Source;
        }

        //주문 취소하는 함수.
        private void OrderCancel(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem != null)
            {
                Food food = lvOrder.SelectedItem as Food;
                food.Count = 0;
                lvOrder.Items.Remove(food);
                SettingTable();
            }
            else
            {
                MessageBox.Show("주문목록에서 음식을 선택해주십시오.","Warning");
            }
        }

        //모든 주문을 취소하는 함수.
        public void OrderAllCancel()
        {
            if (currentTable.FoodList != null)
            {
                foreach (Food item in currentTable.FoodList)
                {
                    item.Count = 0;
                }
                lvOrder.Items.Clear();
                SettingTable();
            }
        }

        //모두 취소 버튼을 누를 때 다시 한번 확인하는 함수.
        private void CheckCancel(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("모든 주문을 취소하시겠습니까?", "Check", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OrderAllCancel();
            }
        }

        //결제 된 item을 payment.foodlist에 저장하는 함수
        private void PaymentTodo()
        {
            if ((MessageBox.Show("결제 방식: " + App.payment.paymentWay + "\n총금액: " + currentTable.TotalPrice + "\n결제 하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
            {
                App.payment.sellingPrice += currentTable.TotalPrice;
                foreach (Food item in currentTable.FoodList)
                {
                    Food food = NewFood(item);
                    if (App.payment.FoodList.Find(x => x.Name == food.Name) != null)
                    {
                        App.payment.FoodList.Find(x => x.Name == food.Name).Count += food.Count;
                    }
                    else
                    {
                        App.payment.FoodList.Add(food);
                    }
                }

                //Debug.Write(lvMenu.Items);
                //Debug.Write(lvOrder.Items);
                //Debug.Write(currentTable.FoodList);
                //Debug.Write(App.payment.FoodList);

                OrderAllCancel();
                //this.Visibility = Visibility.Collapsed;
                BackToMainWindow(null, null);
            }
        }

        private void PaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentTable.FoodList.Count != 0)
            {
                PaymentWin paymentWin = new PaymentWin(); 
                paymentWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                bool? isTodo = paymentWin.ShowDialog();
                if(isTodo==true)
                {
                    PaymentTodo();
                }
                
            }
            else
            {
                MessageBox.Show("메뉴를 추가해주십시오.", "확인", MessageBoxButton.OK);
            }
        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            OrderArgs args = new OrderArgs();
            args.tableId = currentTable.Id;

            if (OnOrderComplete != null)
            {
                OnOrderComplete(this, args);
            }
            this.Visibility = Visibility.Collapsed;
        }

        private void AllButton(object sender, RoutedEventArgs e)
        {
            LoadMenu("All");
        }
        private void BurgerButton(object sender, RoutedEventArgs e)
        {
            LoadMenu("Burger");
        }
        private void SideButton(object sender, RoutedEventArgs e)
        {
            LoadMenu("Side");
        }
        private void DrinkButton(object sender, RoutedEventArgs e)
        {
            LoadMenu("Drink");
        }

        private void LoadMenu(String category)
        {
            lvMenu.Items.Clear();
            foreach (Food food in App.FoodData.lstFood)
            {
                String food_category = food.Category.ToString();
                if (food_category.Equals(category) || category.Equals("All"))
                {
                    lvMenu.Items.Add(food);
                }
            }
            lvMenu.Items.Refresh();
        }
    }
}
