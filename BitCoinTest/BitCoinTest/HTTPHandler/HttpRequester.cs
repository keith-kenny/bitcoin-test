using System;
using System.Net.Http;

namespace BitCoinTest.HTTPHandler
{
    public class HttpRequester : IHttpRequester
    {
        private string _url;
        private HttpClient _client;
        public bool Enabled { get; private set; }

        public HttpRequester(string url)
        {
            if(string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException($"Cannot use a null/empty url to request on, url = {url}");
            }
            Enabled = false;
            _url = url;
            SetUp();
        }

        private void SetUp()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_url);
            Enabled = true;
        }

        public string GetRequest()
        {
            string returnedInformation = string.Empty;
            if (Enabled)
            {
                var msg = _client.GetAsync(string.Empty).Result;
                if (msg.IsSuccessStatusCode)
                {
                    returnedInformation = msg.Content.ReadAsStringAsync().Result;
                }
            }

            return returnedInformation;
        }
    }
}
