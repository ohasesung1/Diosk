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
                new Food() { Name = "쉬림프", Price = 1000, Count = 0, ImagePath="Image/b1.jpg" },
                new Food() { Name = "쉬림프 아보카도", Price = 1500, Count = 0, ImagePath="Image/b1.jpg"  },
                new Food() { Name = "메뉴3", Price = 2000, Count = 0, ImagePath="Image/b1.jpg" },
                new Food() { Name = "메뉴4", Price = 3000, Count = 0, ImagePath="Image/b1.jpg" },
                new Food() { Name = "메뉴5", Price = 4000, Count = 0, ImagePath="Image/b1.jpg" },
            };

            isLoaded = true;
        }
    }
}
