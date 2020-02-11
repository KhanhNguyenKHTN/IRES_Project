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
            client = new HttpClient() { BaseAddress = new Uri(IRES_Global.GlobalInfo.BaseUrl) };
        }
        
        public async Task<ObservableCollection<TableModel>> GetTableByPos(string pos)
        {
            string url = @"/table/position/" + pos;

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
        public async Task<bool> PostOrder(string tableList, DateTime dt)
        {
            string url = @"/order";
            var json = @"{  ""dateCheckin"" : """+ dt.ToString("yyyy-MM-dd HH:mm:ss") + @""",  ""timeCheckin"" : """ + dt.ToString("yyyy-MM-dd HH:mm:ss") + @""",  ""tables"": [ " + tableList + "  ]}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return true;

            }
            return false;
        }
    }
}
