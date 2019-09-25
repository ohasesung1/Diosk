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

        public void SetTable(Core.Table table)
        {
            currentTable = table;
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

            if (!(lvOrder.Items.Contains(food)))
            {
                lvOrder.Items.Add(food);
            }

            food.Count++;
            lvOrder.Items.Refresh();
            SettingTable();
        }

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

        private void FoodImgPreview(object sender, RoutedEventArgs e)
        {
            //Food food = ((ListViewItem)sender).Content as Food;
            //BitmapImage bImage = new BitmapImage();
            //bImage.BeginInit();
            //bImage.UriSource = new Uri(food.ImagePath, UriKind.Relative);
            //bImage.EndInit();
            Image image = (Image)sender;
            selectFoodImg.Source = image.Source;
        }

        private void orderCancel(object sender, RoutedEventArgs e)
        {
            if (lvOrder.SelectedItem != null)
            {
                lvOrder.Items.Remove(lvOrder.SelectedItem);
            }
        }

        private void orderAllCancel(object sender, RoutedEventArgs e)
        {
            lvOrder.Items.Clear();
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
