using Diosk.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Diosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static Client client = new Client();
        public static FoodDataSource FoodData = new FoodDataSource();
        public static TableDataSource TableData = new TableDataSource();
        public static Core.Payment payment = new Core.Payment();
    }
}

