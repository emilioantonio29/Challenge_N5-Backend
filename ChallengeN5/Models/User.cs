using System.ComponentModel.DataAnnotations;

namespace ChallengeN5.Models
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }
}
