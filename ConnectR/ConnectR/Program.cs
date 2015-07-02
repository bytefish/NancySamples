using Microsoft.Owin.Hosting;
using System;

namespace ConnectR
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:8080";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
