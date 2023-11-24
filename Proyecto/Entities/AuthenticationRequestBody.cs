using System.ComponentModel.DataAnnotations;

namespace Proyecto.Entities
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
