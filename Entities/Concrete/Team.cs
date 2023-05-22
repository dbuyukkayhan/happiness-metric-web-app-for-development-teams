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
        public bool IsActive { get; set; } 

        public List<UserTeam> UserTeams { get; set; }
        public List<Sprint> Sprints { get; set; }
        public List<Post> Posts { get; set; }
    }
}
