using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Business.Models
{
    public class PermissionListRangeViewModel
    {
        [Range(0, int.MaxValue)]
        public int initial { get; set; }

        [Range(0, int.MaxValue)]
        public int limit { get; set; }
    }

    public class PermissionViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int permissionTypeId { get; set; }
    }

}
