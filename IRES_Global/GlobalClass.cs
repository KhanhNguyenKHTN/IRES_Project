using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IRES_Global
{
    public static class GlobalClass
    {
        public static ObservableCollection<Food> ListOrders = new ObservableCollection<Food>();

        public static string TableCode;
        
    }
}
