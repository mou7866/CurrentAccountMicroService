using Banking.CurrentAccount.Application.DTOs.Account;
using Banking.CurrentAccount.Application.Wrappers;
using System.Threading.Tasks;

namespace Banking.CurrentAccount.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
