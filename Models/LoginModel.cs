using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    /// <summary>
    /// Login Model Required for Authentication
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
