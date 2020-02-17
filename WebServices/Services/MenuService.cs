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
            client = new HttpClient() { BaseAddress = new Uri( IRES_Global.GlobalInfo.BaseUrl)};
        }

        public async Task<ObservableCollection<Food>> GetAllFood()
        {
            try
            {
                string url = @"/dish/type/KHAI VỊ";

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
            catch
            {
                return null;
            }
            
        }

        public async Task<ObservableCollection<Food>> GetFoodByType(string type)
        {
            try
            {
                string url = @"/dish/type/" + type;

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
            catch
            {
                return null;
            }
            
        }

        public async Task<ObservableCollection<Food>> GetFoodByName(string name)
        {
            try
            {
                string url = @"/dish/search/" + name;

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
            catch
            {
                return null;
            }

        }

        public async Task<Order> PutOrder(Order t, List<Food> dishes)
        {
            try
            {
                string url = @"/order/update/id/" + t.orderId;

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
    }
}
