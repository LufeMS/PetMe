using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class AdoptionMail
    {
        public int Id { get; set; }

        public int AdoptionId { get; set; }
        public virtual Adoption Adoption { get; set; }

        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime SentDate { get; set; }
        //flag de já foi lida
    }
}