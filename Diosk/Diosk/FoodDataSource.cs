using Diosk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk
{
    public class FoodDataSource
    {
        bool isLoaded = false;

        public List<Food> lstFood;

        public void load()
        {
            if (isLoaded) return;

            lstFood = new List<Food>()
            {
                new Food() { Name = "쉬림프", Price = 1000, Count = 0 },
                new Food() { Name = "쉬림프 아보카도", Price = 1500, Count = 0 },
            };

            isLoaded = true;
        }
    }
}
