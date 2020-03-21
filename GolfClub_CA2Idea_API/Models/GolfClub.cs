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

        public virtual ICollection<Golfer> GolferGUI { get; set; }

        public string CompName { get; set; }

        //public virtual ICollection<Competition> CompName { get; set; }

        public GolfClub()
        {
        }


    }
}