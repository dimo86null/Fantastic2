using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantastic2.Models
{
    public class Team
    {
        public int ID { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeGames { get; set; }

        [InverseProperty("GuestTeam")]
        public virtual ICollection<Game> AwayGames { get; set; }
    }
}