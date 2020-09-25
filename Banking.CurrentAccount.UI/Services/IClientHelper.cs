using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.UI.Services
{
    public interface IClientHelper
    {
        string BaseURI { get; }
        Task<HttpClient> CreateHttpClientAsync(string token = null);
    }
}
