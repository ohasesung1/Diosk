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
using System.Threading;
using System.Windows.Threading;

namespace Diosk
{
    /// <summary>
    /// LoadingWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadingWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public LoadingWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(0.05);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            App.TableData.Load();
            App.FoodData.Load();


            //this.Visibility = Visibility.Hidden;
            //MainWindow main = new MainWindow();
            //main.ShowDialog();
            login.Visibility = Visibility.Visible;
            timer.Stop();
        }
    }
}
