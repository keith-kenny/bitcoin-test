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
            // Set Up for Main Thread

            // Typically this would be in some configuration but I think for these purposes it can remain here.
            var urlToConnectTo = "https://api.coindesk.com/v1/bpi/currentprice.json";
            var httpRequester = new HttpRequester(urlToConnectTo);
            BitCoinDisplayer displayer = new BitCoinDisplayer(httpRequester);

            // Start main thread
            MainThread(displayer);

        }

        // This will display and update the curren bit coint price whilst you allow the console to run
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
