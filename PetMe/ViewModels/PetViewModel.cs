using PetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class PetViewModel
    {
        public ApplicationUser UserInfo { get; set; }
        public Pet PetInfo { get; set; }
        public ApplicationUser OwnerInfo { get; set; }
    }
}