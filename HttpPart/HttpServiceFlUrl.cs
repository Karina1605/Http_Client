using MongoDbExample.Models;
using Service_Client_Example.HttpPart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp5.HttpPart
{
    class HttpServiceFlUrl : IDataBaseOperations
    {
        public async Task<bool> AddUser(User user)
        {
            var request = await "https://localhost:44324/api/"
                .AppendPathSegment("Users")
                .WithHeader("type", "application/json")
                .PostJsonAsync(new { lastName =user.LastName, firstname =user.FirstName, logIn =user.LogIn});
            if (request.StatusCode >= 400)
                return false;
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var request = await "https://localhost:44324/api/"
                .AppendPathSegment("Users")
                .WithHeader("type", "application/json")
                .GetJsonListAsync();
            var res = (from l in request select new User() { LastName = l.lastName, FirstName = l.firstName, LogIn = l.logIn }).ToList();
            return res;
        }

        public async Task<User> GetUserById(string id)
        {
            var request = await "https://localhost:44324/api/"
                .AppendPathSegment("Users")
                .AppendPathSegment("GetById")
                .AppendPathSegment(id)
                .WithHeader("type", "application/json")
                .GetJsonAsync();
            var res = new User() {LastName =request.lastName, FirstName =request.firstName, LogIn = request.logIn };
            return res;
        }
    }
}
