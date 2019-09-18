using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Core
{
    public class Food
    {
        public string Name { get; set; }

        public int Price { get; set; }

        private int count;    

        public int Count {
            get {
                return count;
            }
            set {
                count = value;
                if(count < 0)
                {
                    count = 0;
                }
            }
        }

        public string ImagePath { get; set; }

        public eCategory Category { get; set; }


        public Food()
        {

        }

        public Food(String name, int price, int count, String imagePath, eCategory category)
        {
            this.Name = name;
            this.Price = price;
            this.Count = count;
            this.ImagePath = imagePath;
            this.Category = category;
        }
    }

}
