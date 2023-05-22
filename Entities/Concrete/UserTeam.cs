using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserTeam
    {
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
