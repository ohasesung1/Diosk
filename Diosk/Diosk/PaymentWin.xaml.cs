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
using System.Windows.Shapes;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for PaymentWin.xaml
    /// </summary>
    public partial class PaymentWin : Window
    {
        public PaymentWin()
        {
            InitializeComponent();
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            Payment paymentWay;
            paymentWay = Payment.Card;

            PaymentTodo(paymentWay);
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            Payment paymentWay;
            paymentWay = Payment.Cash;

            PaymentTodo(paymentWay);
        }

        private void PaymentTodo(Payment paymentWay)
        {
            Core.Table table = new Core.Table();

            table.TotalPrice = 1000;

            if ((MessageBox.Show("결제 방식: " + paymentWay + "\n총금액: " + table.TotalPrice + "\n결제 하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
            {
                table.totalSales = table.totalSales + table.TotalPrice;
                Debug.Write(table.totalSales);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

    }
}
