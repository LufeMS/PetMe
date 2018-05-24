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
        //public PetPicture[] Pictures { get; set; }
        public string DonoId { get; set; }
        public ApplicationUser Dono { get; set; }
        //public int TpAnimalId { get; set; }
        //public T TpAnimal { get; set; }
        [Required]
        [Display(Name = "Nome do Pet")]
        public string Name { get; set; }

        //Tratar idade para considerar meses
        [Required]
        [Display(Name = "Idade")]
        public byte Age { get; set; }

        //Colocar uma tabela alternativa de raças ou deixar campo livre
        //Talvez não seja um campo obrigatorio
        [Required]
        [Display(Name = "Raça")]
        public string Subspecies { get; set; }

        [Required]
        [Display(Name = "Cor")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Peso")]
        public float Weight { get; set; }

        [Required]
        [Display(Name = "Tamanho")]
        public string Size { get; set; } //trocar para enum ou classe banco

        [Required]
        [Display(Name = "Vacinado?")]
        public bool Vaccinated { get; set; }

        [Required]
        [Display(Name = "Adestrado?")]
        public bool Trained { get; set; }

        [Required]
        [Display(Name = "Castrado")]
        public bool Castrated { get; set; }

        [Required]
        [Display(Name = "Cuidados Especiais?")]
        public bool SpecialCare { get; set; }

        [Display(Name = "Mais detalhes sobre os cuidados")]
        public string DetailsSpecCare { get; set; }

        [Display(Name = "Sobre")]
        public string MoreDetails { get; set; }
    }
}