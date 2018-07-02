using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class ContactMail
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}