using PetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class AdoptionViewModel
    {
        public Pet PetInfo { get; set; }
        public Adoption Adoption { get; set; }
        public ApplicationUser OwnerInfo { get; set; }
        public ApplicationUser InterestedPartyInfo { get; set; }
        public string CurrentUserId { get; set; }
    }
}