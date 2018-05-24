using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class State
    {
        public int Id { get; set; }
        //public int CountryID { get; set; }
        //public virutal Country Country { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Abbreviation { get; set; }

        public int UFCode { get; set; }
    }
}