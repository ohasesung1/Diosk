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
        public List<Food> FoodList { get; set; }

        public Payment Payment { get; set; }

        public int TotalPrice { get; set; } // 테이블 총 결제 금액

        public int totalSales { get; set; } // 총 매출 금액

        public DateTime Time { get; set; }  //최근 주문시간
    }
}
