using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class County
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}