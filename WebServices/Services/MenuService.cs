using Model.Models;
using Model.Models.Menu;
using Model.Models.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.Services
{

    class JsonDetach
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public ObservableCollection<Food> Data { get; set; }
    }

    class JsonOrderDetach
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Order Data { get; set; }
    }
    public class MenuService
    {
        private HttpClient client;

        public MenuService()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<Food>> GetAllFood()
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/dish/type/KHAI VỊ";

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
                    return new ObservableCollection<Food>();
                }
            }
            catch
            {
                Console.WriteLine("Không thể kết nối");
                return new ObservableCollection<Food>();
            }
            
        }

        public async Task<ObservableCollection<Food>> GetFoodByType(string type)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/dish/type/" + type;

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
                    return new ObservableCollection<Food>();
                }
            }
            catch
            {
                Console.WriteLine("Không thể kết nối");
                return new ObservableCollection<Food>();
            }
            
        }

        public async Task<ObservableCollection<Food>> GetFoodByName(string name)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/dish/search/" + name;

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
                    return new ObservableCollection<Food>();
                }
            }
            catch
            {
                return new ObservableCollection<Food>();
            }

        }

        public async Task<Order> PutOrder(Order t, List<Food> dishes)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/order/update/id/" + t.orderId;

                PutOrder listOrder = new PutOrder();
                foreach (var item in dishes)
                {
                    listOrder.dishes.Add(new FoodOrder(item));
                }

                var json = JsonConvert.SerializeObject(listOrder);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var resContent = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<JsonOrderDetach>(resContent);

                    return data.Data;

                }
                Console.WriteLine("ERROR: Can't put order");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: Put Order Error");
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<bool> Payment(PaymentModel total)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/customer/payment/order";
                SenderObject s = new SenderObject(total);
                s.OrderId = IRES_Global.GlobalInfo.Order.orderId;
                var body = JsonConvert.SerializeObject(s);
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Không thể kết nối");
                return false;
            }
        }
        
    }
}
