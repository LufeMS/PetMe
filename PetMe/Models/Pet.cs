using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMe.Models
{
    public class Pet
    {

        /*  LISTA DE COISAS PARA IMPLEMENTAR
         *  Fotos do pet (implementar classe tanto para fotos do animal quanto pessoas: classe image)
         *  Decidir os campos que irão no endereço do animal --check
         *  Adicionar o tipo de animal (classe PetType, decidir como será implementada) --check
         *  Considerar a idade do animal em meses e quando o mesmo foi maior que 12, transformar em ano na view --check
         *  Decidir se raça sera um campo livre e se aparecerá no filtro (Acredito que seja campo livre e não apareça no filtro) --check
        */

        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        [Required]
        public string Name { get; set; }

        public byte AgeInMonths { get; set; }

        public byte PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }

        public byte PetBreedTypeId { get; set; }
        public virtual PetBreedType PetBreedType { get; set; }
        public string BreedDetail { get; set; }

        public byte PetSizeId { get; set; }
        public virtual PetSize PetSize { get; set; }

        public string Color { get; set; }

        public bool Vaccinated { get; set; }

        public bool Trained { get; set; }

        public bool Castrated { get; set; }

        public bool SpecialCare { get; set; }

        public string DetailsSCare { get; set; }

        public string Description { get; set; }

        /* ANIMAL ADDRESS */
        public bool LivesWithOwner { get; set; }

        [Required]
        [MaxLength(8)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(65)]
        public string Address { get; set; }

        [Required]
        [MaxLength(8)]
        public string AddressNumber { get; set; }

        [MaxLength(50)]
        public string AddressComplement { get; set; }

        public int CountyId { get; set; }
        public virtual County County { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        /* CONTROL FIELDS*/
        public DateTime AddedIn { get; set; }
        public bool Active { get; set; }
    }
}