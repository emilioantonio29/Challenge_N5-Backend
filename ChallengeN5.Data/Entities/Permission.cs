using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Lastname { get; set; }

        // Navigation Property
        public virtual PermissionType PermissionType { get; set; }

        [ForeignKey("PermissionType")]
        public int PermissionTypeId { get; set; }

        public DateTime Date { get; set; }
    }
    public class PermissionTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime Date { get; set; }
    }
}
