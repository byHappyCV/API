using System;
using System.Net.Http;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var client = new AuthorClient("http://localhost:56098/", httpClient);
            var result = client.GetAllAsync().GetAwaiter().GetResult();

            Console.WriteLine(result.ToString());
            Console.ReadKey();

        }
    }
}
