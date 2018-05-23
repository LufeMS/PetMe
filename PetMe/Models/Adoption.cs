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
        public ApplicationUser InterestedUser { get; set; }
        public int AnimalId { get; set; }
        public Pet Animal { get; set; }
        public int AdoptionStatusId { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public DateTime AdoptionStart { get; set; }
        public DateTime? AdoptionEnd { get; set; }
        //Adicionar comentarios de ambas as partes e fotos
    }
}