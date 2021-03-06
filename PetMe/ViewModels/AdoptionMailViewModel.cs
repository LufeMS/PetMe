﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.ViewModels
{
    public class AdoptionMailViewModel
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public int AdoptionId { get; set; }
        public int AnimalId { get; set; }
        public string Text { get; set; }
        public DateTime SentDate { get; set; }
    }
}