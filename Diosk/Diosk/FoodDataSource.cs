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
                new Food() { Name = "언빌리버블버거", Price = 1000, Count = 1, ImagePath = "Image/b1.jpg", Category = eCategory.Burger},
                new Food() { Name = "인크레더블버거", Price = 1000, Count = 1, ImagePath = "Image/b2.jpg", Category = eCategory.Burger},
                new Food() { Name = "마살라버거", Price = 1000, Count = 1, ImagePath = "Image/b3.jpg", Category = eCategory.Burger},
            };

            isLoaded = true;
        }
    }
}
