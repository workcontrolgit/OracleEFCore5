using OracleEFCore5.Application.DTOs.Email;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
