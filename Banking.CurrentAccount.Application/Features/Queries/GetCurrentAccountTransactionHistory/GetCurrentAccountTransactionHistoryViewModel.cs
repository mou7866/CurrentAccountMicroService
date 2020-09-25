using Banking.CurrentAccount.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CurrentAccount.Application.Features.Queries.GetCurrentAccountTransactionHistory
{
    public class GetCurrentAccountTransactionHistoryViewModel
    {
        public long TransactionId { get; set; }
        public string TransactionDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal RunningBalance { get; set; }
        public TransactionType TransactionType { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
