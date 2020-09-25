using Banking.CurrentAccount.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory
{
    public class GetCurrentAccountTransactionHistoryParameter : RequestParameter
    {
        public int? CustomerId { get; set; }
        public int? AccountId { get; set; }
    }
}
