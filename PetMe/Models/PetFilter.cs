using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class PetFilter
    {
        public int? CountyId { get; set; }
        public int? StateId { get; set; }
        public int? PetSizeId { get; set; }
        public int? PetTypeId { get; set; }
        public int? PetGenderId { get; set; }
        public int? PetBreedTypeId { get; set; }
        public bool Vaccinated { get; set; }
        public bool Trained { get; set; }
        public bool Castrated { get; set; }
        public bool SpecialCare { get; set; }
        public PetAgeRanges? AgeRange { get; set; }

        public IEnumerable<County> Counties { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<PetSize> PetSizes { get; set; }
        public IEnumerable<PetType> PetTypes { get; set; }
        public IEnumerable<PetBreedType> PetBreedTypes { get; set; }
        public IEnumerable<PetGender> PetGenders { get; set; }

        public enum PetAgeRanges
        {
            [Display(Name = "Menor que 1 ano")]
            lessThanOne = 1,

            [Display(Name = "Entre 1 e 5 anos")]
            betweenOneAndFive = 2,

            [Display(Name = "Maior que 6 anos")]
            greaterThanSix = 3
        }
    }
}