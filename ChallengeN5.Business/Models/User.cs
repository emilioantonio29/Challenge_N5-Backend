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
        public string username { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
    }

    public class UserResponseModel
    {
        public int id { get; set; }
        public string username { get; set; }
    }
}
