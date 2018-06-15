using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetMe.ViewModels;

namespace PetMe.Models
{
    public class Adoption
    {
        public int Id { get; set; }

        public string InterestedUserId { get; set; }
        public virtual ApplicationUser InterestedUser { get; set; }
        public bool InterestedUserPermission { get; set; }

        public string PetOwnerId { get; set; }
        public virtual ApplicationUser PetOwner { get; set; }
        public bool PetOwnerPermission { get; set; }

        public int AnimalId { get; set; }
        public virtual Pet Animal { get; set; }

        public int AdoptionStatusId { get; set; }
        public virtual AdoptionStatus AdoptionStatus { get; set; }

        public DateTime AdoptionStart { get; set; }
        public DateTime? AdoptionEnd { get; set; }

        //Adicionar comentarios de ambas as partes e fotos
    }
}