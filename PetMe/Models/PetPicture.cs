using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class PetPicture
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public byte[] Picture { get; set; }
        public bool MainPic { get; set; }
    }
    
}