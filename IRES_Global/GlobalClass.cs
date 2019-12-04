using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IRES_Global
{
    public static class GlobalClass
    {
        public static ObservableCollection<CardItemModel> ListOrders = new ObservableCollection<CardItemModel>();

        public static string TableCode;
        
    }
}
