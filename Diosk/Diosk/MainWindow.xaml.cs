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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Diosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            order.OnOrderComplete += Order_OnOrderComplete;
        }

        // 주문 후 테이블 정보 새로고침
        private void Order_OnOrderComplete(object sender, OrderArgs args)
        {
            TableCtrl tablectrl = tbList.SelectedItem as TableCtrl;
           

            foreach (Table list in App.TableData.lstTable)
            {
                if (list.Id == args.tableId)
                {
                    tablectrl.SetTable(list);

                    
                }
                Debug.WriteLine(list.Id + "/" + list.Time);
                if (list.FoodList != null)
                {

                    foreach (Food food in list.FoodList)
                    {
                        Debug.WriteLine(food.Name + "*" + food.Count);
                    }
                }
                
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("load MainWindow");

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(0.01)
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            LoadTable();
        }

        private void LoadTable()
        {
            App.TableData.Load();
            foreach (Table table in App.TableData.lstTable)
            {
                TableCtrl tableCtrl = new TableCtrl();
                tableCtrl.SetTable(table);

                tbList.Items.Add(tableCtrl);
            }
        }

        //선택한 테이블 객체 넘겨주기, 화면 이동
        private void TbList_SelectionChanged(object sender, SelectionChangedEventArgs e)    
        {
            TableCtrl tableCtrl = (tbList.SelectedItem as TableCtrl);
            
            order.SetTable(tableCtrl.GetTable());

            order.Visibility = Visibility.Visible;
            

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            clock.Content = DateTime.Now.ToString("yyyy년MM월dd일\n   hh : mm : ss");
        }


        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            total.viewPrice(App.payment.totalSales);
            total.Visibility = Visibility.Visible;
        }


    }
}
