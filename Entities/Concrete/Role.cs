﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool RoleStatus { get; set; }
        public DateTime RoleCreatedDate { get; set; }
        public DateTime RoleModifiedDate { get; set; }

    }
}
