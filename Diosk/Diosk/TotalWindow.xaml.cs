using Diosk.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Table = Diosk.Core.Table;

namespace Diosk
{
    /// <summary>
    /// TotalWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TotalWindow : UserControl
    {
        List<Food> salesFoods = new List<Food>();

        public TotalWindow()
        {
            InitializeComponent();
        }

        //총 매출 금액 보여주는 함수
        public void viewSales(int sellingPrice)
        {
            totalSalse.Text = sellingPrice + "원";
        }

        //메인으로 돌아가는 함수
        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        //결제 된 메뉴 리스트 보여주는 함수
        public void viewSalesMenu(List<Food> paymentItem)
        {
            foreach(Food item in paymentItem)
            {
                item.totalPrice = item.Price * item.Count;
            }

            paymentList.ItemsSource = paymentItem;
            paymentList.Items.Refresh();
        }

        private void Menu_Click_1(object sender, RoutedEventArgs e)
        {
            viewSalesMenu(App.payment.FoodList);
        }

        //카테고리 별로 결제된 메뉴 보여주는 함수
        private void LoadMenu(String category)
        {
            salesFoods.Clear();
            foreach (Food food in App.payment.FoodList)
            {
                String food_category = food.Category.ToString();
                if (food_category.Equals(category))
                {
                    salesFoods.Add(food);
                }
            }
            paymentList.ItemsSource = salesFoods;
            paymentList.Items.Refresh();
        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            LoadMenu("Burger");
        }

        private void Side_Click(object sender, RoutedEventArgs e)
        {
            LoadMenu("Side");
        }

        private void Drink_Click(object sender, RoutedEventArgs e)
        {
            LoadMenu("Drink");
        }
    }
}
