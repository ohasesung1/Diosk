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

        List<Food> dataSourceList = new List<Food>();
        PaymentWin payment = new PaymentWin();

        private Core.Table currentTable;

        public OrderWindow()
        {
            InitializeComponent();
            this.Loaded += OrderWindow_Loaded;
        }
        private void OrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.FoodData.load();
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
        }

        //주문 메뉴의 -버튼 누를때 사용하는 함수.
        private void SubtractOrderCount(object sender, RoutedEventArgs e)
        {
            Button subBtn = (Button)sender;
            if (subBtn.DataContext is Food)
            {
                Food food = (Food)subBtn.DataContext;
                food.Count -= 1;
                removeCheckFood(food);
            }

            lvOrder.Items.Refresh();
            SettingTable();
        }

        private void removeCheckFood(Food food)
        {
            if (food.Count <= 0)
            {
                lvOrder.Items.Remove(food);
            }
        }

        //주문목록에 Food 추가하는 함수.
        private void AddOrderMenu(object sender, RoutedEventArgs e)
        {
            Food food = newFood(((ListViewItem)sender).DataContext as Food);
            if (food == null) return;

            if (lvOrder.Items.Cast<Food>().ToList<Food>().Find(x => x.Name == food.Name) == null)
            {
                lvOrder.Items.Add(food);
            }

            lvOrder.Items.Cast<Food>().ToList<Food>().Find(x => x.Name == food.Name).Count++;
            lvOrder.Items.Refresh();
            SettingTable();
        }

        private Food newFood(Food item)
        {
            Food food = new Food();

            food.Name = item.Name;
            food.Price = item.Price;
            food.Count = 0;
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
            currentTable.Time = DateTime.Now;
        }

        //클릭시 푸드 이미지 미리보기를 해주는 함수.
        private void FoodImgPreview(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;
            selectFoodImg.Source = image.Source;
        }

        //주문 취소하는 함수.
        private void orderCancel(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem != null)
            {
                Food food = lvOrder.SelectedItem as Food;
                food.Count = 0;
                lvOrder.Items.Remove(food);
                SettingTable();
            }
        }

        //모든 주문을 취소하는 함수.
        public void orderAllCancel(object sender, RoutedEventArgs e)
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
        //결제 된 item을 payment.foodlist에 저장하는 함수
        private void PaymentTodo()
        {
            if ((MessageBox.Show("결제 방식: " + App.payment.paymentWay + "\n총금액: " + currentTable.TotalPrice + "\n결제 하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
            {
                App.payment.sellingPrice += currentTable.TotalPrice;
                foreach (Food item in currentTable.FoodList)
                {
                    Food food = newFood(item);
                    food.Count = item.Count;
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

                //orderAllCancel(null, null);
                this.Visibility = Visibility.Collapsed;
            }
        }

        //총 결제 금액 계산 함수
        private int totalPrice()
        {
            int temp = 0;

            foreach (Core.Table table in App.TableData.lstTable)
            {
                temp += table.TotalPrice;
            }

            return temp;
        }

        private void PaymentBtn_Click(object sender, RoutedEventArgs e)
        {
                    payment.ShowDialog();

                    PaymentTodo();
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
            dataSourceList.Clear();
            foreach (Food food in App.FoodData.lstFood)
            {
                String food_category = food.Category.ToString();
                if (food_category.Equals(category) || category.Equals("All"))
                {
                    dataSourceList.Add(food);
                }
            }
            lvMenu.ItemsSource = dataSourceList;
            lvMenu.Items.Refresh();
        }
    }
}
