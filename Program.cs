using MongoDbExample.Models;
using Service_Client_Example.HttpPart;
using System;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        private static IDataBaseOperations _operator;
        private static int i = 0;

        static async Task Main(string[] args)
        {
            _operator = new HttpProxy(new HttpService());
            await DoWork();
            Console.WriteLine("Hello World!");
        }
        private static async Task DoWork()
        {
            string id = "61321ad312eb1cd10885cacc";
            int j = 0;
            while (j<10)
            {
                switch (i)
                {
                    case 0:
                        var usrs = await _operator.GetAllUsers();
                        break;
                    case 1:
                        var user = new User() { LastName = "Ivanov", FirstName = "Ivan", LogIn = "Bvc@qq.ru" };
                        await _operator.AddUser(user);
                        break;
                    case 2:
                        var ur = await _operator.GetUserById(id);
                        break;
                }
                if (i == 0)
                    i = 1;
                else if (i == 1)
                    i = 2;
                else
                    i = 0;
                await Task.Delay(1000);
                j++;
            }
        }
    }
}
