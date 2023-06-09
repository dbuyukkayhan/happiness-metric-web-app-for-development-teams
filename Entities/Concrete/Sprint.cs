﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sprint
    {
        [Key]
        public int SprintId { get; set; }
        public string SprintName { get; set; }
        public DateTime SprintStart { get; set; }
        public DateTime SprintEnd { get; set; }
        public bool IsActive { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}
