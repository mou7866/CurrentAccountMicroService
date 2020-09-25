using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CurrentAccount.Domain.Common
{
    public class Customer : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdentityTypeId { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }

        public ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
