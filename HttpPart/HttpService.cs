using MongoDbExample.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service_Client_Example.HttpPart
{
    public class HttpService : IDataBaseOperations
    {
        private readonly HttpClient _client = new HttpClient();
        
        public async Task<bool> AddUser(User user)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            message.Method = HttpMethod.Post;
            message.RequestUri = new Uri("https://localhost:44324/api/Users/");
            message.Headers.Add("type", "application/json");
            message.Content = System.Net.Http.Json.JsonContent.Create<User>(user);
            var res = await _client.SendAsync(message);
            if (res.IsSuccessStatusCode)
                return true;
            return false;

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            HttpRequestMessage message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri("https://localhost:44324/api/Users/");
            message.Headers.Add("type", "application/json");
            var res =  await _client.SendAsync(message);
            if (!res.IsSuccessStatusCode)
                throw new Exception("Error code : " + res.StatusCode);
            var str = await res.Content.ReadAsStringAsync();
            var ops = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var content =  JsonSerializer.Deserialize<IEnumerable<User>>(str, ops);
            return content;
            
        }

        public async Task<User> GetUserById(string id)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri("https://localhost:44324/api/Users/GetById/"+id);
            message.Headers.Add("type", "application/json");
            var response = await _client.SendAsync(message);
            var json = await response.Content.ReadAsStringAsync();
            var ops = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var res = JsonSerializer.Deserialize<User>(json, ops);
            //var res = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return res;
        }
    }
}
