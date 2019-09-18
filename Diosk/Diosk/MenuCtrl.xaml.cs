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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diosk.Core;

namespace Diosk
{
    /// <summary>
    /// Interaction logic for MenuCtrl.xaml
    /// </summary>
    public partial class MenuCtrl : UserControl
    {
        Core.Menu menu = new Core.Menu();

        public MenuCtrl()
        {
            InitializeComponent();
        }

        public void SetItem(string name, string price)
        {

        }

        public void SetItem(Core.Menu item)
        {
            menu = item;
            UpdateItem();
        }

        private void UpdateItem()
        {
            MenuImage.Source = new BitmapImage(new Uri(menu.ImagePath, UriKind.RelativeOrAbsolute));
            tbName.Text = menu.Name;
            tbPrice.Text = menu.Price.ToString();
            tbCount.Text = menu.Count.ToString();
        }
    }
}
