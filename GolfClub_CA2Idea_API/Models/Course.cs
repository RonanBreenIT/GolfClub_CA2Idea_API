using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GolfClub_CA2Idea_API.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; } // May have more than one course

        public string Name { get; set; }

        public int Holes { get; set; }
        public int HoleNumber { get; set; }

        public int Distance { get; set; }

        public int Index { get; set; }

        public int Par { get; set; }

        public int ClubID { get; set; } // specific to each club

    }
}