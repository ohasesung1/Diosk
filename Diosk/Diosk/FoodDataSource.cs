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
                new Food() { Name = "에그랩(2종)", Price = 1000, Count = 1, ImagePath = "Image/s1.jpg", Category = eCategory.Side},
                new Food() { Name = "콘베지샐러드", Price = 1000, Count = 1, ImagePath = "Image/s2.jpg", Category = eCategory.Side},
                new Food() { Name = "베지샐러드", Price = 1000, Count = 1, ImagePath = "Image/s3.jpg", Category = eCategory.Side},
                new Food() { Name = "슈퍼베리워터주스", Price = 1000, Count = 1, ImagePath = "Image/d1.png", Category = eCategory.Drink},
                new Food() { Name = "레몬홍차", Price = 1000, Count = 1, ImagePath = "Image/d2.jpg", Category = eCategory.Drink},
                new Food() { Name = "복숭아망고스무디", Price = 1000, Count = 1, ImagePath = "Image/d3.jpg", Category = eCategory.Drink},
            };

            isLoaded = true;
        }
    }
}
