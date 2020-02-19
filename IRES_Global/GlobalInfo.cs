using Model.Models.Menu;
using Model.Models.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace IRES_Global
{
    public static class GlobalInfo
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public static string BaseUrl = @"http://172.16.5.189:8081/";

        public static string CustomerName = @"";

        public static Customer CustomerCurrent { get; set; }

        public static Order Order { get; set; }

        public static ObservableCollection<Food> ListOrders = new ObservableCollection<Food>();

        public static string TableCode;

    }
}
