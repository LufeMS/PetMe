using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class AdoptionStatus
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }

        public const int awaitingOwner = 1;
        public const int inProgress = 2;
        public const int finished = 3;
        public const int cancelled = 4;

    }
}