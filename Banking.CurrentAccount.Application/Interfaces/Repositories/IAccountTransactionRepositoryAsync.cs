using Banking.CurrentAccount.Application.Wrappers;
using Banking.CurrentAccount.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.Application.Interfaces.Repositories
{
    public interface IAccountTransactionRepositoryAsync : IGenericRepositoryAsync<Transaction>
    {
        Task<PagedResponse<IReadOnlyList<Transaction>>> GetPagedReponseAccountTransactionHistoryAsync(int? customerId, int? accountId, int pageNumber, int pageSize);
    }
}
