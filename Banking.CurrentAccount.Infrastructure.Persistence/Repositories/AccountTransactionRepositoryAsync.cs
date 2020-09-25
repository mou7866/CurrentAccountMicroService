using Banking.CurrentAccount.Application.Interfaces.Repositories;
using Banking.CurrentAccount.Application.Wrappers;
using Banking.CurrentAccount.Domain.Common;
using Banking.CurrentAccount.Helpers;
using Banking.CurrentAccount.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.Infrastructure.Persistence.Repositories
{
    public class AccountTransactionRepositoryAsync : GenericRepositoryAsync<Transaction>, IAccountTransactionRepositoryAsync
    {
        private readonly DbSet<Transaction> _customerTransactions;

        public AccountTransactionRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _customerTransactions = dbContext.Set<Transaction>();
        }

        public async Task<PagedResponse<IReadOnlyList<Transaction>>> GetPagedReponseAccountTransactionHistoryAsync(int? customerId, int? accountId, int pageNumber, int pageSize)
        {
            var query = _customerTransactions
                        .Include(x => x.Account)
                        .ThenInclude(x => x.Customer)
                        .Where(x => x.Account.CustomerId == customerId && x.AccountId == accountId);

            return await query.ToPagedListAsync(pageNumber, pageSize); ;
        }
    }
}
