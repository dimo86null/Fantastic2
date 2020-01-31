using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantastic2.Models
{
    public class Stats
    {
        [Key]
        [Column(Order = 1)]
        public int GameID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PlayerID { get; set; }
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int DefensiveRebounds { get; set; }
        public int OffensiveRebounds { get; set; }
        public int Rebounds { get { return DefensiveRebounds + OffensiveRebounds; } }
    }
}