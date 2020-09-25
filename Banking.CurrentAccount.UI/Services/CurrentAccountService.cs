using Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory;
using Banking.CurrentAccount.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.UI.Services
{
    public class CurrentAccountService : ICurrentAccountService
    {
        protected readonly IClientHelper _clientHelper;
        public string Token { get; set; }
        public CurrentAccountService(IClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
        }

        public async Task<PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>> GetCurrentAccountHistory(GetCurrentAccountTransactionHistoryParameter filter)
        {
            using (var client = await _clientHelper.CreateHttpClientAsync(Token))
            {
                try
                {
                    var response = await client.GetAsync(client.BaseAddress + $"CurrentAccount?CustomerId={filter.CustomerId}&AccountId={filter.AccountId}&PageNumber={filter.PageNumber}&PageSize={filter.PageSize}");
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>>(responseContent);
                    return result;
                }
                catch (Exception e) 
                { 
                    throw e; 
                }
            }
        }
    }
}
