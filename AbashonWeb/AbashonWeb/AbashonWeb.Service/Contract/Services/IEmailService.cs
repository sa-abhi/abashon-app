using AbashonWeb.Domain.Settings;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
