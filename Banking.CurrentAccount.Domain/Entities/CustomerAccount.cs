using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Banking.CurrentAccount.Domain.Common
{
    public class CustomerAccount : AuditableBaseEntity
    {
        public string AccountNumber { get; set; }
        public decimal RunningBalance { get; set; }
        public string AccountName { get; set; }
        public int AccountTypeId { get; set; }
        public DateTime DateOpened { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
