using Model.Models.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.Services
{
    class JsonLoginDetach
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Customer Data { get; set; }
    }
    public class LoginService
    {
        private HttpClient client;

        public LoginService()
        {
            client = new HttpClient();
        }

        public async Task<bool> Login(string username, string pass)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/customer/customer/login";
                string json = @"{ ""password"": """ + pass + @""", ""userName"": """ + username + @""" }";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var contentData = await response.Content.ReadAsStringAsync();
                    var item = JsonConvert.DeserializeObject<JsonLoginDetach>(contentData);
                    IRES_Global.GlobalInfo.CustomerCurrent = item.Data;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể kết nối");
                return false;
            }
            
        }

        public async Task SignUp(Customer cus)
        {
            try
            {
                string url = IRES_Global.GlobalInfo.BaseUrl + @"/customer/customer/sign-up";
                //string json = @"{ ""password"": """ + pass + @""", ""userName"": """ + username + @""" }";
                string json = JsonConvert.SerializeObject(cus);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    IRES_Global.GlobalInfo.CustomerCurrent = cus;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể kết nối");
            }
        }
    }
}
