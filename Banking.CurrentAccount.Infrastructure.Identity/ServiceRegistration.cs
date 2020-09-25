using Banking.CurrentAccount.Application.Interfaces;
using Banking.CurrentAccount.Infrastructure.Identity.Models;
using Banking.CurrentAccount.Infrastructure.Identity.Services;
using Banking.CurrentAccount.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.CurrentAccount.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            IServiceCollection serviceCollections = services
                .AddEntityFrameworkSqlite()
                .AddDbContext<IdentityContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("IdentityConnection"),
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion
        }
    }
}
