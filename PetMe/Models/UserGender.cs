using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class UserGender
    {
        public int Id { get; set; }

        [Required] 
        [MaxLength(15)]
        public string Name { get; set; }
    }
}