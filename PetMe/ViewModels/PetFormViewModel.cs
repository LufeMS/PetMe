using PetMe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class PetFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        [Required]
        [Display(Name = "Nome do Pet")]
        public string Name { get; set; }

        [Display(Name = "Idade")]
        public byte AgeInMonths { get; set; }

        [Display(Name = "Tipo de Animal")]
        public byte PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }

        [Display(Name = "Tipo de Raça")]
        public byte PetBreedTypeId { get; set; }
        public virtual PetBreedType PetBreedType { get; set; }

        [Display(Name = "Detalhes da Raça")]
        public string BreedDetail { get; set; }

        [Display(Name = "Porte")]
        public byte PetSizeId { get; set; }
        public virtual PetSize PetSize { get; set; }

        [Display(Name = "Nome")]
        public string Color { get; set; }

        [Display(Name = "Vacinado?")]
        public bool Vaccinated { get; set; }

        [Display(Name = "Adestrado?")]
        public bool Trained { get; set; }

        [Display(Name = "Castrado?")]
        public bool Castrated { get; set; }

        [Display(Name = "Necessita de cuidados especiais?")]
        public bool SpecialCare { get; set; }

        [Display(Name = "Detalhe os cuidados")]
        public string DetailsSCare { get; set; }

        [Display(Name = "Conte-nos um pouco sobre seu pet")]
        public string Description { get; set; }

        /* ANIMAL ADDRESS */
        [Display(Name = "Vive no mesmo endereço que o dono?")]
        public bool LivesWithOwner { get; set; }

        [MaxLength(8)]
        [Display(Name = "CEP")]
        public string ZipCode { get; set; }

        [MaxLength(65)]
        [Display(Name = "Logradouro")]
        public string Address { get; set; }

        [MaxLength(8)]
        [Display(Name = "Nº")]
        public string AddressNumber { get; set; }

        [MaxLength(50)]
        [Display(Name = "Complemento")]
        public string AddressComplement { get; set; }

        [Display(Name = "Município")]
        public int? CountyId { get; set; }
        public virtual County County { get; set; }

        [Display(Name = "Estado")]
        public int? StateId { get; set; }
        public virtual State State { get; set; }
    }
}