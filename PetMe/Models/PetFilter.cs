using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class PetFilter
    {
        [Display(Name = "Município")]
        public int? CountyId { get; set; }

        [Display(Name = "Estado")]
        public int? StateId { get; set; }

        [Display(Name = "Porte")]
        public int? PetSizeId { get; set; }

        [Display(Name = "Tipo de Animal")]
        public int? PetTypeId { get; set; }

        [Display(Name = "Sexo")]
        public int? PetGenderId { get; set; }

        [Display(Name = "Raça")]
        public int? PetBreedTypeId { get; set; }

        [Display(Name = "Vacinado?")]
        public bool Vaccinated { get; set; }

        [Display(Name = "Adestrado?")]
        public bool Trained { get; set; }

        [Display(Name = "Castrado?")]
        public bool Castrated { get; set; }

        [Display(Name = "Cuidados Especiais?")]
        public bool SpecialCare { get; set; }

        [Display(Name = "Idade do Pet")]
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