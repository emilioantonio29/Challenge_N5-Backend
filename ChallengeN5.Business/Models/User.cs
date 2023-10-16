using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Business.Models
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }

    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
