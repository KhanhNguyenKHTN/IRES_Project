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
using Model.Models.Order;

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
        public async Task<Order> OrderTable(int id, DateTime dt)
        {
            Order order = new Order()
            {
                tables = new List<TableModel>() { new TableModel() { Id = id} },
                customer = IRES_Global.GlobalInfo.CustomerCurrent,
                DateCheck = dt
            };
            var resOrder = await service.PostOrder(order);
            IRES_Global.GlobalInfo.Order = resOrder;

            return resOrder;
        }
        public async Task<Order> OrderTable(DateTime dt, int quantity)
        {
            var items = ListTables.Where(x => x.IsActived == true).ToList();
            string s = "";

            Order order = new Order() {
                tables = items,
                customer = IRES_Global.GlobalInfo.CustomerCurrent,
                DateCheck = dt,
                quantity = quantity
            };
            var resOrder = await service.PostOrder(order);
            IRES_Global.GlobalInfo.Order = resOrder;

            return resOrder;
        }
    }
}
