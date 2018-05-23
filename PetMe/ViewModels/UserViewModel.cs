using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class UserViewModel
    {
        public string ID { get; set; }

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
        //Trocar string gender por referencia ao banco

        [Display(Name = "Gênero")]
        public char Gender { get; set; }

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
        //Trocar as strings de cidade e estado por referencia ao banco

        [Required]
        [Display(Name = "Cidade")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [MaxLength(50)]
        public string State { get; set; }
        //Adicionar redes sociais
    }
}