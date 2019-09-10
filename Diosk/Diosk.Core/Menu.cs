using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk.Core
{
    public class Menu
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public string ImagePath { get; set; }

        public eCategory Category { get; set; }

        public Menu()
        {

        }

        public Menu(String name, int price, int count, String imagePath, eCategory category)
        {
            this.Name = name;
            this.Price = price;
            this.Count = count;
            this.ImagePath = imagePath;
            this.Category = category;
        }
    }

}
