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
    public partial class OrderWindow : UserControl
    {

        List<Food> asdf = new List<Food>();
        PaymentWin payment = new PaymentWin();
        public OrderWindow()
        {
            InitializeComponent();
            this.Loaded += OrderWindow_Loaded;
        }
        private void OrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.FoodData.load();
            lvMenu.ItemsSource = App.FoodData.lstFood;
        }

        public void SetTable(Core.Table table)
        {
            Debug.WriteLine(table.Id);    //선택한 테이블 아이디 확인
        }

        private void AddOrderCount(object sender, RoutedEventArgs e)
        {
            Button addBtn = (Button)sender;
            if (addBtn.DataContext is Food)
            {
                Food food = (Food)addBtn.DataContext;
                food.Count += 1;
            }

            lvOrder.Items.Refresh();
        }
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
        }

        private void removeCheckFood(Food food)
        {
            if (food.Count <= 0)
            {
                lvOrder.Items.Remove(food);
            }
        }

        private void AddOrderMenu(object sender, RoutedEventArgs e)
        {
            Food food = ((ListViewItem)sender).Content as Food;

            if (food == null) return;

            if (lvOrder.Items.Contains(food))
            {
                food = (lvOrder.Items.GetItemAt(lvOrder.Items.IndexOf(food)) as Food);
                food.Count++;
            }
            else
            {
                lvOrder.Items.Add(food);
            }

            lvOrder.Items.Refresh();
        }

        private void SetTotalPrice(Core.Table table)
        {
            totalPrice.Text += " " + table.TotalPrice;
        }

        private void PaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            payment.ShowDialog();
        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
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
            asdf.Clear();
            foreach (Food food in App.FoodData.lstFood)
            {
                String food_category = food.Category.ToString();
                if (food_category.Equals(category) || category.Equals("All"))
                {
                    asdf.Add(food);
                    Debug.WriteLine(food.Name);
                }
            }
            lvMenu.ItemsSource = asdf;
            lvMenu.Items.Refresh();
        }
    }
}
