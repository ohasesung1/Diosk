using Diosk.Core;
using System;
using System.Collections.Generic;
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

namespace Diosk
{
    /// <summary>
    /// TableCtrl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TableCtrl : UserControl
    {
        Table table = new Table();
        public TableCtrl()
        {
            InitializeComponent();
        }
        public void SetTable(Table table)
        {
            this.table = table;
            UpdateItem();
        }
        public void UpdateItem()
        {
            tbId.Text = table.Id;
            tbTime.Text = table.Time.ToString("hh : mm : ss");
        }
    }
}
