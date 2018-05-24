using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetMe.Models;

namespace PetMe.ViewModels
{
    public class PetListViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Pet> Pets { get; set; }
        public Filter Filter { get; set; }
    }
}