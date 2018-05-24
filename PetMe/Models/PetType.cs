﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class PetType
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}