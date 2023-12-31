﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Data.Entities
{
    public class PermissionType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}
