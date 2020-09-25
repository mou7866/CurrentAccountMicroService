using Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory;
using Banking.CurrentAccount.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.UI.Services
{
    public interface ICurrentAccountService
    {
        Task<PagedResponse<IEnumerable<GetCurrentAccountTransactionHistoryViewModel>>> GetCurrentAccountHistory(GetCurrentAccountTransactionHistoryParameter filter);
    }
}
