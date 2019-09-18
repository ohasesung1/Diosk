﻿using System;
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
using Diosk.Core;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : UserControl
    {
        public OrderWindow()
        {
            InitializeComponent();
            this.Loaded += OrderWindow_Loaded;
        }
        public void AddOrderCount(object sender, RoutedEventArgs e)
        {
            Button addBtn = (Button)sender;
            if (addBtn.DataContext is Food)
            {
                Food food = (Food)addBtn.DataContext;
                food.Count += 1;
            }

            lvOrder.Items.Refresh();
        }
        public void SubtractOrderCount(object sender, RoutedEventArgs e)
        {
            Button subBtn = (Button)sender;
            if (subBtn.DataContext is Food)
            {
                Food food = (Food)subBtn.DataContext;
                food.Count -= 1;
            }

            lvOrder.Items.Refresh();
        }

        public void AddOrderMenu(object sender, RoutedEventArgs e)
        {
            Food food = (lvMenu.SelectedItem as Food);

            if (food == null) return;

            if (lvOrder.Items.Contains(food))
            {

                return;
            }

            lvOrder.Items.Add(food);

            lvOrder.Items.Refresh();
        }

        private void OrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.FoodData.load();
#if true
            lvMenu.ItemsSource = App.FoodData.lstFood;
#else
            LoadMenu();
#endif
        }

        private void LoadMenu()
        {
            foreach (Food food in App.FoodData.lstFood)
            {
                FoodCtrl foodCtrl = new FoodCtrl();
                foodCtrl.SetItem(food);
                lvMenu.Items.Add(foodCtrl);
            }
        }
    }
}
