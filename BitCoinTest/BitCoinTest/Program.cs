using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using BitCoinTest.HTTPHandler;
using BitCoinTest.JSONHandler;

namespace BitCoinTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Temporary Code, Test to grab JSON information
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(");
            HttpResponseMessage msg = client.GetAsync("").Result;
            msg.EnsureSuccessStatusCode();
            string result = msg.Content.ReadAsStringAsync().Result;
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{result}");

            // Set Up for Main Thread

            // Typically this would be in some configuration but I think for these purposes it can remain here.
            var urlToConnectTo = "https://api.coindesk.com/v1/bpi/currentprice.json";
            var httpRequester = new HttpRequester(urlToConnectTo);
            var httpHandler = new BitCoinHttpHandler(httpRequester);

        }

        static void MainThread(BitCoinDisplayer bitCoinDisplayer)
        {
            while(true)
            {
                bitCoinDisplayer.GetAndDisplayBitCoinPrice();
                Thread.Sleep(1000);
            }
        }
    }
}
