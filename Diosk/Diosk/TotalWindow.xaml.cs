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

namespace Diosk
{
    /// <summary>
    /// TotalWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TotalWindow : UserControl
    {
        Core.Table table;

        public TotalWindow()
        {
            InitializeComponent();

            viewPrice();
        }

        private void viewPrice()
        {
            Debug.Write(table.TotalPrice);
            totalPrice.Text = table.totalSales.ToString() + "원";
        }

        private void MainWinBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
