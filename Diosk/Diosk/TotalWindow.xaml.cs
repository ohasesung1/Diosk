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
        List<Food> foods = new List<Food>();

        public TotalWindow()
        {
            InitializeComponent();
        }


        public void viewSalse(int sellingPrice)
        {
            totalSalse.Text = sellingPrice + "원";
        }

        private void MainWinBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        //private void Menu_Click(List<Food> paymentItem)
        //{
        //    paymentList.ItemsSource = paymentItem;
        //    paymentList.Items.Refresh();
        //}

        public void viewSalseMenu(List<Food> paymentItem)
        {
            paymentList.ItemsSource = paymentItem;
            paymentList.Items.Refresh();
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Click_1(object sender, RoutedEventArgs e)
        {
            viewSalseMenu(App.payment.FoodList);
        }
    }
}
