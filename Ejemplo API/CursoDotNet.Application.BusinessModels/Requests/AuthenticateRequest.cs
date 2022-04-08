using System.ComponentModel.DataAnnotations;

namespace CursoDotNet.Application.BusinessModels.Requests
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
