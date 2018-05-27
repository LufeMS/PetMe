using PetMe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public byte[] Avatar { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(35)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        [MaxLength(35)]
        public string Surname { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Gênero")]
        public int GenderId { get; set; }
        public virtual IEnumerable<UserGender> Gender { get; set; }

        [Required]
        [Display(Name = "Nº Documento")]
        [MaxLength(14)]
        public string DocumentNumber { get; set; }

        [Required]
        [Display(Name = "Logradouro")]
        [MaxLength(65)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Nº")]
        [MaxLength(8)]
        public string AddressNumber { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(100)]
        public string AddressComplement { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        [MaxLength(50)]
        public string District { get; set; }

        [Required]
        [Display(Name = "CEP")]
        [MaxLength(8)]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        [MaxLength(50)]
        public string County { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [MaxLength(50)]
        public string State { get; set; }
    }
}