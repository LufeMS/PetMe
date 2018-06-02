using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class Filter
    {
        public int CountyId { get; set; }
        public int StateId { get; set; }
        public int PetSizeId { get; set; }
        public int PetTypeId { get; set; }
        public int PetGenderId { get; set; }
        public int PetBreedTypeId { get; set; }
        public int AgeInMonths { get; set; }
        public bool Vaccinated { get; set; }
        public bool Trained { get; set; }
        public bool Castrated { get; set; }
        public bool SpecialCare { get; set; }
    }
}