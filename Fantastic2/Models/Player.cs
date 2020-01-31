using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fantastic2.Models
{
    public class Player
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<Stats> Stats { get; set; }
    }
}