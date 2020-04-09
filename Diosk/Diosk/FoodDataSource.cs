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

        public void Load()
        {
            if (isLoaded) return;

            lstFood = new List<Food>()
            {
                new Food() { Name = "언빌리버블버거", Price = 5100, Count = 0, ImagePath = "Image/b1.jpg", Category = eCategory.Burger},
                new Food() { Name = "인크레더블버거", Price = 4900, Count = 0, ImagePath = "Image/b2.jpg", Category = eCategory.Burger},
                new Food() { Name = "마살라버거",     Price = 3800, Count = 0, ImagePath = "Image/b3.jpg", Category = eCategory.Burger},
                new Food() { Name = "살사리코버거",   Price = 4500, Count = 0, ImagePath = "Image/b4.png", Category = eCategory.Burger},
                new Food() { Name = "치즈베이컨버거", Price = 4500, Count = 0, ImagePath = "Image/b5.jpg", Category = eCategory.Burger},
                new Food() { Name = "딥치즈버거", Price = 4000, Count = 0, ImagePath = "Image/b6.jpg", Category = eCategory.Burger},
                new Food() { Name = "불싸이버거", Price = 3600, Count = 0, ImagePath = "Image/b7.jpg", Category = eCategory.Burger},
                new Food() { Name = "리샐버거", Price = 4200, Count = 0, ImagePath = "Image/b8.jpg", Category = eCategory.Burger},
                new Food() { Name = "화이트갈릭버거", Price = 4100, Count = 0, ImagePath = "Image/b9.jpg", Category = eCategory.Burger},
                new Food() { Name = "스파이시불고기버거", Price = 3200, Count = 0, ImagePath = "Image/b10.jpg", Category = eCategory.Burger},
                new Food() { Name = "스파이시디럭스불고기버거", Price = 4200, Count = 0, ImagePath = "Image/b11.jpg", Category = eCategory.Burger},
                new Food() { Name = "디럭스불고기버거", Price = 4000, Count = 0, ImagePath = "Image/b12.jpg", Category = eCategory.Burger},
                new Food() { Name = "싸이버거", Price = 3400, Count = 0, ImagePath = "Image/b13.jpg", Category = eCategory.Burger},
                new Food() { Name = "휠렛버거", Price = 3600, Count = 0, ImagePath = "Image/b14.jpg", Category = eCategory.Burger},
                new Food() { Name = "햄치즈휠렛버거", Price = 3900, Count = 0, ImagePath = "Image/b15.jpg", Category = eCategory.Burger},
                new Food() { Name = "할라피뇨통살버거", Price = 3900, Count = 0, ImagePath = "Image/b16.jpg", Category = eCategory.Burger},
                new Food() { Name = "할라피뇨통가슴살버거", Price = 3900, Count = 0, ImagePath = "Image/b17.jpg", Category = eCategory.Burger},
                new Food() { Name = "통새우버거", Price = 2900, Count = 0, ImagePath = "Image/b18.jpg", Category = eCategory.Burger},
                new Food() { Name = "불고기버거", Price = 3000, Count = 0, ImagePath = "Image/b19.jpg", Category = eCategory.Burger},

                new Food() { Name = "에그랩(2종)",    Price = 2300, Count = 0, ImagePath = "Image/s1.jpg", Category = eCategory.Side},
                new Food() { Name = "콘베지샐러드",   Price = 2300, Count = 0, ImagePath = "Image/s2.jpg", Category = eCategory.Side},
                new Food() { Name = "베지샐러드",     Price = 2000, Count = 0, ImagePath = "Image/s3.jpg", Category = eCategory.Side},
                new Food() { Name = "라이스&치킨너겟", Price = 4000, Count = 0, ImagePath = "Image/s4.jpg", Category = eCategory.Side},
                new Food() { Name = "어니언치즈감자",  Price = 2500, Count = 0, ImagePath = "Image/s5.jpg", Category = eCategory.Side},
                new Food() { Name = "치즈감자",  Price = 2500, Count = 0, ImagePath = "Image/s6.jpg", Category = eCategory.Side},
                new Food() { Name = "치즈할라피뇨너겟(8조각)",  Price = 3000, Count = 0, ImagePath = "Image/s7.jpg", Category = eCategory.Side},
                new Food() { Name = "할라피뇨너겟(10조각)",  Price = 3000, Count = 0, ImagePath = "Image/s8.jpg", Category = eCategory.Side},
                new Food() { Name = "리코타샐러드",  Price = 3000, Count = 0, ImagePath = "Image/s9.jpg", Category = eCategory.Side},
                new Food() { Name = "김떡만",  Price = 3000, Count = 0, ImagePath = "Image/s10.jpg", Category = eCategory.Side},
                new Food() { Name = "텐터로인(2조각)",  Price = 2000, Count = 0, ImagePath = "Image/s11.jpg", Category = eCategory.Side},
                new Food() { Name = "프라이랩(2종)",  Price = 2500, Count = 0, ImagePath = "Image/s12.jpg", Category = eCategory.Side},
                new Food() { Name = "팝콘만두(3종)",  Price = 2500, Count = 0, ImagePath = "Image/s13.jpg", Category = eCategory.Side},
                new Food() { Name = "팝콘볼",  Price = 2500, Count = 0, ImagePath = "Image/s14.jpg", Category = eCategory.Side},
                new Food() { Name = "케이준양념감자",  Price = 3000, Count = 0, ImagePath = "Image/s15.jpg", Category = eCategory.Side},
                new Food() { Name = "콘샐러드",  Price = 1500, Count = 0, ImagePath = "Image/s16.jpg", Category = eCategory.Side},
                new Food() { Name = "치킨샐러드",  Price = 2500, Count = 0, ImagePath = "Image/s17.jpg", Category = eCategory.Side},
                new Food() { Name = "치즈스틱(2조각)",  Price = 1900, Count = 0, ImagePath = "Image/s18.jpg", Category = eCategory.Side},
                new Food() { Name = "고구마치즈볼",  Price = 2500, Count = 0, ImagePath = "Image/s19.jpg", Category = eCategory.Side},
                new Food() { Name = "휠랩",  Price = 2500, Count = 0, ImagePath = "Image/s20.jpg", Category = eCategory.Side},

                new Food() { Name = "슈퍼베리워터주스", Price = 2000, Count = 0, ImagePath = "Image/d1.png", Category = eCategory.Drink},
                new Food() { Name = "레몬홍차",        Price = 2500, Count = 0, ImagePath = "Image/d2.jpg", Category = eCategory.Drink},
                new Food() { Name = "복숭아망고스무디", Price = 3000, Count = 0, ImagePath = "Image/d3.jpg", Category = eCategory.Drink},
                new Food() { Name = "레몬딸기스무디",   Price = 3000, Count = 0, ImagePath = "Image/d4.jpg", Category = eCategory.Drink},
                new Food() { Name = "레몬에이드",  Price = 2200, Count = 0, ImagePath = "Image/d5.jpg", Category = eCategory.Drink},
                new Food() { Name = "홍차",  Price = 2000, Count = 0, ImagePath = "Image/d6.jpg", Category = eCategory.Drink},
                new Food() { Name = "레몬티",  Price = 2000, Count = 0, ImagePath = "Image/d7.jpg", Category = eCategory.Drink},
                new Food() { Name = "허브복숭아티",  Price = 2000, Count = 0, ImagePath = "Image/d8.jpg", Category = eCategory.Drink},
                new Food() { Name = "스트로베리밀크",  Price = 2500, Count = 0, ImagePath = "Image/d9.jpg", Category = eCategory.Drink},
                new Food() { Name = "스위트망고",  Price = 2500, Count = 0, ImagePath = "Image/d10.jpg", Category = eCategory.Drink},
                new Food() { Name = "딸기스무디",  Price = 2800, Count = 0, ImagePath = "Image/d11.jpg", Category = eCategory.Drink},
                new Food() { Name = "망고스무디",  Price = 2800, Count = 0, ImagePath = "Image/d12.jpg", Category = eCategory.Drink},
                new Food() { Name = "라떼",  Price = 3300, Count = 0, ImagePath = "Image/d13.jpg", Category = eCategory.Drink},
                new Food() { Name = "아메리카노",  Price = 2000, Count = 0, ImagePath = "Image/d14.jpg", Category = eCategory.Drink},
                new Food() { Name = "콜라",  Price = 1600, Count = 0, ImagePath = "Image/d15.jpg", Category = eCategory.Drink},
                new Food() { Name = "오렌지주스",  Price = 2000, Count = 0, ImagePath = "Image/d16.jpg", Category = eCategory.Drink},
                new Food() { Name = "청포도에이드",  Price = 2200, Count = 0, ImagePath = "Image/d17.jpg", Category = eCategory.Drink},
                new Food() { Name = "망고에이드",  Price = 2200, Count = 0, ImagePath = "Image/d18.jpg", Category = eCategory.Drink},
                new Food() { Name = "복숭아에이드",  Price = 2200, Count = 0, ImagePath = "Image/d19.jpg", Category = eCategory.Drink},
            };

            isLoaded = true;
        }
    }
}
