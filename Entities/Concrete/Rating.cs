using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public int RatingScore { get; set; }
        public string RatingComment { get; set; }
        public bool IsActive { get; set; }

        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        
    }
}
