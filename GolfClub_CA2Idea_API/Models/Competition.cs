using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace GolfClub_CA2Idea_API.Models
{
    public enum CompType
    {
        Strokeplay, Stableford
    }

    public class Competition
    {
        [Key]
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public CompType Type { get; set; }

        public GolfClub Club { get; set; } // specific to each club

        public virtual ICollection<Golfer> GUI { get; set; } // Many Golfers in each Comp
    }
}