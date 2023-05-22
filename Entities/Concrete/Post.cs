using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public string PostContent { get; set; }
        public DateTime PostTime { get; set; }

        public List<Comment> Comments { get; set; }


    }
}
