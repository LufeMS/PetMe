using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class PetType
    {
        public byte Id { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}