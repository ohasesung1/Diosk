using System;
using System.Collections.Generic;
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

        PaymentWin payment = new PaymentWin();
        public OrderWindow()
        {
            InitializeComponent();
            this.Loaded += OrderWindow_Loaded;
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
            if(food.Count <= 0)
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


        private void OrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.FoodData.load();
            lvMenu.ItemsSource = App.FoodData.lstFood;
            //LoadMenu();

        }

        private void LoadMenu()
        {
            App.FoodData.load();
            foreach (Food food in App.FoodData.lstFood)
            {
                FoodCtrl foodCtrl = new FoodCtrl();
                foodCtrl.SetItem(food);
                lvMenu.Items.Add(foodCtrl);
            }
        }

        private void PaymentBtn_Click(object sender, RoutedEventArgs e)
        {
            payment.ShowDialog();
        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
