using MongoDbExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Client_Example.HttpPart
{
    class HttpProxy : IDataBaseOperations
    {
        private IDataBaseOperations _operations;
        
        public HttpProxy(IDataBaseOperations operations)
        {
            _operations = operations;
        }
        public async Task<bool> AddUser(User user)
        {
            var res = await _operations.AddUser(user);
            if (res)
                Console.WriteLine("User {0}, {1}, with login {2} was successfully added", user.LastName, user.FirstName, user.LogIn);
            else
                Console.WriteLine("User {0}, {1}, with login {2} was not added", user.LastName, user.FirstName, user.LogIn);
            return res;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var res = await _operations.GetAllUsers();
                Console.WriteLine("There are {0} users in database now", res.Count());
                return res;
            }
            catch
            {
                Console.WriteLine("Could not get gata from database");
                throw;
            }
        }

        public async Task<User> GetUserById(string id)
        {
            try
            {
                var res = await _operations.GetUserById(id);
                Console.WriteLine("User {0}, {1}, with login {2} was successfully got", res.LastName, res.FirstName, res.LogIn);
                return res;
            }
            catch
            {
                Console.WriteLine("Could not get gata from database");
                throw;
            }
        }
    }
}