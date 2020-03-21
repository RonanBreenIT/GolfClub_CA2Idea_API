using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GolfClub_CA2Idea_API.Models
{
    public class Golfer
    {
        [Key]
        public int GUI { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        private int handicap;
        public int Handicap
        {
            get
            {
                return this.handicap;
            }
            set
            {
                if (value > 28)
                {
                    this.handicap = 28;
                }
                else if (value < 0)
                {
                    this.handicap = 0;
                }
                else
                {
                    this.handicap = value;
                }
            }
        }

        public int ClubID { get; set; }

        public int CompID { get; set; }

        [DisplayFormat(NullDisplayText = "No Score")]
        public int? StokeScore { get; set; }  // ? allows Nullable score

        [DisplayFormat(NullDisplayText = "No Score")]
        public int? StableScore { get; set; }

        //public virtual ICollection<Competition> CompName { get; set; }

        public Golfer()
        {

        }
    }
}