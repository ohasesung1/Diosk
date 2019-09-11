using Diosk.Core;
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

namespace Diosk
{
    /// <summary>
    /// Interaction logic for FoodCtrl.xaml
    /// </summary>
    public partial class FoodCtrl : UserControl
    {
        Food food = new Food();

        public FoodCtrl()
        {
            InitializeComponent();
        }

        public void SetItem(string name, string price)
        {

        }

        public void SetItem(Food item)
        {
            food = item;
        }

        private void UpdateItem()
        {
            tbName.Text = food.Name;
            tbPrice.Text = food.Price.ToString();
            tbCount.Text = food.Count.ToString();
        }
    }
}
