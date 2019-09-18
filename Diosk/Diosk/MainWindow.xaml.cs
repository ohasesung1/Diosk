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
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("load MainWindow");

            App.FoodData.load();
            lvFood.ItemsSource = App.FoodData.lstFood;
            //LoadMenu();
        }


        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            Food food = (lvFood.SelectedItem as Food);
            if (food == null) return;
            food.Count++;
            lvFood.Items.Refresh();
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Food food = (lvFood.SelectedItem as Food);
            if (food == null) return;
            food.Count--;
            lvFood.Items.Refresh();
        }

        //private void LoadMenu()
        //{
        //    foreach(Food food in App.FoodData.lstFood)
        //    {
        //        FoodCtrl foodCtrl = new FoodCtrl();
        //        foodCtrl.SetItem(food);

        //        lvFood.Items.Add(foodCtrl);
        //    }
        //}
    }
}
