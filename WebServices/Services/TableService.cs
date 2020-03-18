using Model.Models.Order;
using Model.Models.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.Services.Table
{
    class JsonDetach
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public ObservableCollection<TableModel> Data { get; set; }
    }

    public class TableService
    {
        private HttpClient client;

        public TableService()
        {
            client = new HttpClient();
        }
        
        public async Task<ObservableCollection<TableModel>> GetTableByPos(string pos)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/table/position/" + pos;

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //JsonDetach det = new JsonDetach();
                    var Items = JsonConvert.DeserializeObject<JsonDetach>(content);

                    return Items.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Không thể kết nối");
                return null;
            }
        }
        public async Task<Order> PostOrder(Order t)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/order";
                var json = JsonConvert.SerializeObject(t);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var resContent = await response.Content.ReadAsStringAsync();

                    var detach = JsonConvert.DeserializeObject<JsonOrderDetach>(resContent);
                    return detach.Data;

                }
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Không thể kết nối");
                return null;
            }
            
        }

        public async Task GetOrderByCode(string code)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + $"/order/code/{code}";
                var res = await client.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    var resContent = await res.Content.ReadAsStringAsync();

                    var detach = JsonConvert.DeserializeObject<JsonOrderDetach>(resContent);

                    IRES_Global.GlobalInfo.Order = detach.Data;
                    IRES_Global.GlobalInfo.ListOrders = new ObservableCollection<Model.Models.Menu.Food>();
                    foreach (var item in detach.Data.orderDetail)
                    {

                        var food = new Model.Models.Menu.Food()
                        {
                            Id = item.dish.Id,
                            LabName = item.dish.LabName,
                            Cost = item.dish.Cost,
                            Description = item.dish.Description,
                            ImagesSource = item.dish.ImagesSource,
                            Note = item.dish.Note,
                            OrderQuantity = item.quantity,
                            Quantity = item.quantity,
                            Type = item.dish.Type,
                            RealCost = item.dish.RealCost
                        };
                        IRES_Global.GlobalInfo.ListOrders.Add(food);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
