using System;
using System.Net.Http;
using APISwagger;

namespace NewConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new HttpClient();
            var client = new APISwagger.Client.AuthorClient(test){BaseUrl = "http://localhost:56098/" };
            var result = client.GetAllAsync().GetAwaiter().GetResult();
            foreach (var v in result)
            {
                Console.WriteLine($"{v.Name} {v.Surname}");
            }
        }
    }
}
