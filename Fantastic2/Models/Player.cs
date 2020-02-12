using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fantastic2.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get { return Firstname + " " + Lastname; } }
        public virtual Profile Profile { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<PlayerStats> PlayerStats { get; set; }
    }
}