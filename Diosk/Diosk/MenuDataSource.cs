using Diosk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk
{
    public class MenuDataSource
    {
        bool isLoaded = false;

        public List<Menu> lstMenu;

        
        public void Load()
        {
            if (isLoaded) return;
            lstMenu = new List<Menu>()
            {
                new Menu() { Name = "언빌리버블버거", Price = 1000, Count = 1, ImagePath = "Image/b1.jpg", Category = eCategory.Buger},
                new Menu() { Name = "인크레더블버거", Price = 1000, Count = 1, ImagePath = "Image/b2.jpg", Category = eCategory.Buger},
                new Menu() { Name = "마살라버거", Price = 1000, Count = 1, ImagePath = "Image/b3.jpg", Category = eCategory.Buger},
            };

            isLoaded = true;
        }
    }
}
