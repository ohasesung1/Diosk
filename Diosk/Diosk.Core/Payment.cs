using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Core
{
    public class Payment
    {
        public List<Food> FoodList { get; set; }

        //public int TotalPrice { get; set; } // 테이블 총 결제 금액

        public int sellingPrice { get; set; } // 총 매출 금액

        public PaymentWay paymentWay { get; set; }

        public Payment()
        {
            FoodList = new List<Food>();
        }
    }
}
