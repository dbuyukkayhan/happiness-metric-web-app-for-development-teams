using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public bool TeamStatus { get; set; }
        public DateTime TeamCreatedDate { get; set; }
        public DateTime TeamModifiedDate { get; set; }

    }
}
