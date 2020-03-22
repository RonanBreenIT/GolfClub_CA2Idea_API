using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GolfClub_CA2Idea_API.Models
{
    public class GolfClub
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Golfer> Golfers { get; set; } // Many Golfers in each Comp

        public virtual ICollection<Competition> Comps { get; set; }

        public GolfClub()
        {
        }
    }
}