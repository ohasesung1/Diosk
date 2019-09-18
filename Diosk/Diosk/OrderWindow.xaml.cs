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
            if (addBtn.DataContext is Core.Menu)
            {
                Core.Menu menu = (Core.Menu)addBtn.DataContext;
                menu.Count += 1;
            }

            lvOrder.Items.Refresh();
        }
        public void SubtractOrderCount(object sender, RoutedEventArgs e)
        {
            Button subBtn = (Button)sender;
            if (subBtn.DataContext is Core.Menu)
            {
                Core.Menu menu = (Core.Menu)subBtn.DataContext;
                menu.Count -= 1;
            }

            lvOrder.Items.Refresh();
        }

        public void AddOrderMenu(object sender, RoutedEventArgs e)
        {
            Core.Menu menu = (lvMenu.SelectedItem as Core.Menu);

            if (menu == null) return;

            if (lvOrder.Items.Contains(menu)) return;

            lvOrder.Items.Add(menu);

            lvOrder.Items.Refresh();
        }

        private void OrderWindow_Loaded(object sender, RoutedEventArgs e)
        {
            App.MenuData.Load();
#if true
            lvMenu.ItemsSource = App.MenuData.lstMenu;
#else
            LoadMenu();
#endif
        }

        //private void LoadMenu()
        //{
        //    foreach(Core.Menu menu in App.MenuData.lstMenu)
        //    {
        //        MenuCtrl menuCtrl = new MenuCtrl();
        //        menuCtrl.SetItem(menu);
        //        lvMenu.Items.Add(menuCtrl);
        //    } 
        //}
    }
}
