﻿using Diosk.Core;
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
using System.ComponentModel;

namespace Diosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        TableCtrl SelectedTablectrl = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            order.OnOrderComplete += Order_OnOrderComplete;
            login.OnLoginComplete += SetLoginTime;
            App.client.ServerClosed += Client_serverClosed;
        }

        private void Client_serverClosed(object sender, ServerArgs args)
        {
            MessageBox.Show(args.Message);
        }

        private void SetLoginTime(object sender, OrderArgs args)
        {
            String LoginTime = DateTime.Now.ToString("hh : mm : ss");
            loginTime.Content = "  최근접속시간\n   " + LoginTime;
        }


        // 주문 후 테이블 정보 새로고침
        private void Order_OnOrderComplete(object sender, OrderArgs args)
        {
            foreach (Table list in App.TableData.lstTable)
            {
                if (list.Id == args.tableId)
                {
                    SelectedTablectrl.SetTable(list);
                }                
            }
        }

        // 테이블 로딩과 현재 시간 표시
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(0.01)
            };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            LoadTable();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            clock.Content = DateTime.Now.ToString("yyyy년MM월dd일\n   hh : mm : ss");
        }

        //생성된 테이블을 리스트에 추가
        private void LoadTable()
        {
            foreach (Table table in App.TableData.lstTable)
            {
                TableCtrl tableCtrl = new TableCtrl();
                tableCtrl.SetTable(table);

                tbList.Items.Add(tableCtrl);
            }
        }

        //선택한 테이블 객체 넘겨주기, 주문 화면 이동
        private void TbList_SelectionChanged(object sender, SelectionChangedEventArgs e)    
        {
            if (tbList.SelectedIndex == -1)
                return;

            TableCtrl tableCtrl = (tbList.SelectedItem as TableCtrl);

            if (tableCtrl == null)
                return;

            SelectedTablectrl = tableCtrl;

            order.SetTable(tableCtrl.GetTable());

            order.Visibility = Visibility.Visible;

            tbList.SelectedIndex = -1;
        }

        //통계화면으로 이동
        private void ViewStatistic(object sender, RoutedEventArgs e)
        {
            total.ViewSales(App.payment.sellingPrice);
            total.ViewSalesMenu(App.payment.FoodList);
            String sendPrice = App.payment.sellingPrice.ToString();
            App.client.SendMessage("@All" + "#" + sendPrice);
            total.Visibility = Visibility.Visible;
        }

        private void LogoutTodo(object sender, RoutedEventArgs e)
        {
            login.SetLogoutTime(this, null);
            App.client.Socket_Close();
            login.Visibility = Visibility.Visible;
        }
    }
}
