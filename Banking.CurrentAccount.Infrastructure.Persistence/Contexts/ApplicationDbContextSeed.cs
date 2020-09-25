using Banking.CurrentAccount.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.Infrastructure.Persistence.Contexts
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            #region Customers
            if (!context.Customers.Any())
            {
                for (int i = 1; i < 2; i++)
                {
                    context.Customers.Add(new Customer
                    {
                        Id = 1,
                        BirthDate = DateTime.Now.AddYears(-i),
                        GenderId = i % 2 > 0 ? 1 : 2,
                        Name = $"John",
                        LastName = $"Smith {i}",
                        IdentityNumber = "12344555"
                    }); 

                }
                await context.SaveChangesAsync();
            }
            #endregion
            #region Accounts
            if (!context.Accounts.Any())
            {
                for (int i = 1; i < 10; i++)
                {
                    context.Accounts.Add(new CustomerAccount
                    {
                        Id = i,
                        AccountName = $"Test Account {i}",
                        AccountNumber = $"Test {i}",
                        AccountTypeId = 1,
                        CustomerId = context.Customers.First().Id,
                        DateOpened = DateTime.UtcNow,
                        RunningBalance = i * 100                        
                    });

                }
                await context.SaveChangesAsync();

            }
            #endregion
            #region Transactions
            // Seed, if necessary
            if (!context.Transactions.Any())
            {
                for (int i = 1; i < 10; i++)
                {
                    context.Transactions.Add(new Transaction
                    {
                        AccountId = context.Accounts.First().Id,
                        Created = DateTime.Now,
                        TransactionAmount = i+1,
                        TransactionDate = DateTime.Now,
                        TransactionDescription = "Test",
                        TransactionType = i % 2 == 0 ? 1 : 2,
                        RunningBalance = i-1,
                        Id = i,
                    });
                }

                await context.SaveChangesAsync();
            }
            #endregion

        }
    }
}
