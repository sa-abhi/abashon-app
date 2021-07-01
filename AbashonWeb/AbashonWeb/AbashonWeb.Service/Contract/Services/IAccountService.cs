using AbashonWeb.Domain.Auth;
using AbashonWeb.Domain.Common;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.Services
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> LoginAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
    }
}
