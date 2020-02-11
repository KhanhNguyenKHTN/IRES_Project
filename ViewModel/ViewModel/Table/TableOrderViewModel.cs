using Model.Models.Table;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using WebServices.Services.Table;
using System.Threading.Tasks;
using System;

namespace ViewModel.ViewModel.Table
{
    public class TableOrderViewModel : BaseViewModel
    {
        TableService service;

        private ObservableCollection<TableModel> _ListTables;
        public ObservableCollection<TableModel> ListTables { get => _ListTables; set { _ListTables = value; OnPropertyChanged(); } }

        private bool _IsRefresh;
        public bool IsRefresh { get => _IsRefresh; set { _IsRefresh = value; OnPropertyChanged(); } }



        public TableOrderViewModel()
        {
            service = new TableService();
        }
        public async void GetListTable(string v)
        {
            IsRefresh = true;
            ListTables = await service.GetTableByPos(v);
            IsRefresh = false;
        }
        public async Task<bool> OrderTable(int id, DateTime dt)
        {
            var s = @"{ ""tableId"" : " + id + @"  }";
            return await service.PostOrder(s, dt);
        }
        public async Task<bool> OrderTable( DateTime dt)
        {
            var items = ListTables.Where(x => x.IsActived == true).ToList();
            string s = "";
            //{    "tableId" : 1   }
            for (int i = 0; i < items.Count; i++)
            {
                if(i == items.Count - 1)
                {
                    s += @"{ ""tableId"" : " + items[i].Id + @"  }";
                }
                else
                {
                    s += @"{ ""tableId"" : " + items[i].Id + @"  },";
                }
            }

            return await service.PostOrder(s, dt);
        }
    }
}
