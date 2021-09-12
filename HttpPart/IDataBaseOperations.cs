using MongoDbExample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Client_Example.HttpPart
{
    public interface IDataBaseOperations
    {
        public Task<bool> AddUser(User user);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(string id);
    }
}
