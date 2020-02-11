using Model.Models.Menu;
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
    public class MenuService
    {
        private HttpClient client;

        public MenuService()
        {
            client = new HttpClient() { BaseAddress = new Uri( IRES_Global.GlobalInfo.BaseUrl)};
        }

        public async Task<ObservableCollection<Food>> GetAllFood()
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

        public async Task<ObservableCollection<Food>> GetFoodByType(string type)
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
    }
}
