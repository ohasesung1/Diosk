using Diosk.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diosk
{
    public class TableDataSource
    {
        bool isLoaded = false;

        public List<Table> lstTable;

        public void Load()
        {
            if (isLoaded) return;

            lstTable = new List<Table>()
            {
                new Table() { Id="1",TotalPrice=0 },
                new Table() { Id="2",TotalPrice=0 },
                new Table() { Id="3",TotalPrice=0 },
                new Table() { Id="4",TotalPrice=0 },
                new Table() { Id="5",TotalPrice=0 },
                new Table() { Id="6",TotalPrice=0 },
            };
            isLoaded = true;
        }
    }
}
