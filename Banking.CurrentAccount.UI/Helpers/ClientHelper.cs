using Banking.CurrentAccount.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.UI.Helpers
{
    public class ClientHelper : IClientHelper
    {
        private readonly IConfiguration _config;

        public string BaseURI => _config.GetValue<string>("ApiLink");

        public ClientHelper(IConfiguration config)
        {
            _config = config;
        }

        public async Task<HttpClient> CreateHttpClientAsync(string token = null)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseURI)
            };

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }
    }
}
