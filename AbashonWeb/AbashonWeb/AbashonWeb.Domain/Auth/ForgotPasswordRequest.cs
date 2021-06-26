using System.ComponentModel.DataAnnotations;

namespace AbashonWeb.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
