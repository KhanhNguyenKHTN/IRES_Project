﻿using Model.Models.Menu;
using Model.Models.Notification;
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

        public static string BaseUrl = @"http://192.168.0.199:8081/";

        public static string CustomerName = @"";

        public static Customer CustomerCurrent { get; set; }

        public static Order Order { get; set; }

        public static ObservableCollection<Food> ListOrders = new ObservableCollection<Food>();

        public static string TableCode;

        public static bool IsEmployee = false;

        public static List<NotificationModel> ListNotis = new List<NotificationModel>();
    }
}
