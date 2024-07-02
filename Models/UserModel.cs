using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    /// <summary>
    /// User Model Required For Login
    /// </summary>
    public class UserModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
