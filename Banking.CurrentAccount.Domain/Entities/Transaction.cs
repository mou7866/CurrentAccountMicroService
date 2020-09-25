using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Banking.CurrentAccount.Domain.Common
{
    public class Transaction : AuditableBaseEntity
    {
        public string TransactionDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal RunningBalance { get; set; }
        public int TransactionType { get; set; }
        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }

        public virtual CustomerAccount Account { get; set; }
    }
}
