using Banking.CurrentAccount.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(entity =>
            {
                entity.HasMany(b => b.CustomerAccounts)
                      .WithOne(b => b.Customer)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<CustomerAccount>(entity =>
            {
                entity.HasMany(b => b.Transactions)
                      .WithOne(b => b.Account)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
