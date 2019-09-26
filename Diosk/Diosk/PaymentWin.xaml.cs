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
        public Core.Table currentTable;

        public PaymentWin()
        {
            InitializeComponent();
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            PaymentWay paymentWay;
            paymentWay = PaymentWay.Card;
            this.Hide();
        }

        public string Cash_Click(object sender, RoutedEventArgs e)
        {
            PaymentWay paymentWay;
            paymentWay = PaymentWay.Cash;
            this.Hide();

            return paymentWay.ToString();
        }

        private int totalPrice()
        {
            int temp = 0;

            foreach (Core.Table table in App.TableData.lstTable)
            {
                temp += table.TotalPrice;
            }

            return temp;
        }

    }
}
