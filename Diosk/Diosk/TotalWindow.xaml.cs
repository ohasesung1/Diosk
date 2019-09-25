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

        public TotalWindow()
        {
            InitializeComponent();

            //this.Loaded += MainWindow_Loaded;
            //tbList.MouseDoubleClick += tbClick;
        }

        public void viewPrice(int totalSalse)
        {
            Debug.Write(App.table.totalSales);
            totalPrice.Text = totalSalse + "원";
        }

        private void MainWinBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {

        
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            //App.TableData.Load();
            //int count = 0;
            //foreach (Table table in App.TableData.lstTable)
            //{
            //    Debug.Write(table.FoodList);
            //}
        }
    }
}
