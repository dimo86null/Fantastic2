using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fantastic2.Models
{
    public class Game
    {
        public int ID { get; set; }

        //public int HomeTeamID { get; set; }
        //[ForeignKey("HomeTeamID")]
        public virtual Team HomeTeam { get; set; }

        //public int GuestTeamID { get; set; }
        //[ForeignKey("GuestTeamID")]
        public virtual Team GuestTeam { get; set; }
        public virtual ICollection<Stats> Stats { get; set; }
    }
}