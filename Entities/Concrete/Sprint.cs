using System;
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
        public int TeamId { get; set; }
        public string SprintName { get; set; }
        public string SprintStatus { get; set; }
        public DateTime SprintStartDate { get; set; }
        public DateTime SprintEndDate { get; set; }
    }
}
