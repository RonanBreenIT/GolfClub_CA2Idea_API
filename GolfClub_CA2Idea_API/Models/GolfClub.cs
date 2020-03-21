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

        //public string CompName { get; set; }

        public virtual ICollection<Competition> CompName { get; set; }

        public GolfClub()
        {
        }

        public GolfClub(int _id, string _name, List<Golfer> _GUI, List<Competition> _compName)
        {
            ID = _id;
            Name = _name;
            GolferGUI = _GUI;
            CompName = _compName;
        }
    }
}