using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class Adoption
    {
        public int Id { get; set; }

        public int InterestedUserId { get; set; }
        public virtual ApplicationUser InterestedUser { get; set; }

        public int PetOwnerId { get; set; }
        public virtual ApplicationUser PetOwner { get; set; }

        public int AnimalId { get; set; }
        public virtual Pet Animal { get; set; }

        public int AdoptionStatusId { get; set; }
        public virtual AdoptionStatus AdoptionStatus { get; set; }

        public DateTime AdoptionStart { get; set; }
        public DateTime? AdoptionEnd { get; set; }
        //Adicionar comentarios de ambas as partes e fotos
    }
}