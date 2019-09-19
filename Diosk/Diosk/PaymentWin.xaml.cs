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

            if (MessageBox.Show("결제 하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

            }
            else
            {

            }
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("결제 하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

            }
            else
            {

            } 
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
