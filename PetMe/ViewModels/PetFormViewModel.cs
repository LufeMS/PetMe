﻿using PetMe.Models;
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

        public  HttpPostedFileBase[] Pictures { get; set; }

        public List<PetPicture> PetPictures { get; set; }

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
        public IEnumerable<PetType> PetTypes { get; set; }

        [Display(Name = "Tipo de Raça")]
        public byte PetBreedTypeId { get; set; }
        public IEnumerable<PetBreedType> PetBreedTypes { get; set; }

        [Display(Name = "Detalhes da Raça")]
        public string BreedDetail { get; set; }

        [Display(Name = "Sexo")]
        public byte PetGenderId { get; set; }
        public IEnumerable<PetGender> PetGenders { get; set; }

        [Display(Name = "Porte")]
        public byte PetSizeId { get; set; }
        public IEnumerable<PetSize> PetSizes { get; set; }

        [Display(Name = "Cor")]
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

        [MaxLength(50)]
        [Display(Name = "Bairro")]
        public string District { get; set; }

        [Display(Name = "Município")]
        public string CountyView { get; set; }

        [Display(Name = "Estado")]
        public string StateView { get; set; }
    }
}