using PetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class AdoptionListViewModel
    {
        public List<AdoptionViewModel> Adoptions { get; set; }
        public PetFilter Filter { get; set; }
    }
}