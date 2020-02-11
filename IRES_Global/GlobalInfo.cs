using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IRES_Global
{
    public static class GlobalInfo
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public static string BaseUrl = @"http://192.168.1.99:8081/";


    }
}
