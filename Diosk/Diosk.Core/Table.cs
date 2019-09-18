using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Core
{
    public class Table
    {
        public String Id;
        public String Orders { get; set; }
        public List<Food> FoodList { get; set; }

        public Payment Payment { get; set; }

        public int TotalPrice { get; set; }

        public DateTime Time { get; set; }  //최근 주문시간
    }
}
