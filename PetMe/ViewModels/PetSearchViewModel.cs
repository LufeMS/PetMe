using PetMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class PetSearchViewModel
    {
        public List<Pet> Pets { get; set; }
        public byte Age { get; set; }
        public string Subspecies { get; set; }
        public float Weight { get; set; }
        public bool Vacinated { get; set; }
        public bool SpecialCare { get; set; }
        public bool Trained { get; set; }
        public bool Castrated { get; set; }
    }
}