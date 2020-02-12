using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fantastic2.Models
{
    public class Profile
    {
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public string Country { get; set; }
        public Position Position { get; set; }
    }
}