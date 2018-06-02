using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetMe.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        /* LISTA DE ITENS PARA IMPLEMENTAR
        * Adicionar data de criação do usuario
        * Adicionar funcao de reportar
        * Adicionar redes sociais
        * adicionar homepage
        * Adicionar ultima vez visto
        * Adicionar avatar
        */

        //public byte[] Avatar { get; set; }

        [MaxLength(35)]
        public string FirstName { get; set; }

        [MaxLength(35)]
        public string Surname { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? GenderId { get; set; }
        public virtual UserGender Gender { get; set; }

        [MaxLength(14)]
        public string DocumentNumber { get; set; }

        [MaxLength(65)]
        public string Address { get; set; }

        [MaxLength(8)]
        public string AddressNumber { get; set; }

        [MaxLength(50)]
        public string AddressComplement { get; set; }

        [MaxLength(50)]
        public string District { get; set; }

        [MaxLength(8)]
        public string ZipCode { get; set; }

        public int? CountyId { get; set; }
        public virtual County County { get; set; }

        public int? StateId { get; set; }
        public virtual State State { get; set; }

        public bool? FormOk { get; set; } //Flag para saber se a pessoa esta com o cadastro ok
        public bool? Deleted { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetBreedType> PetBreedTypes { get; set; }
        public DbSet<PetSize> PetSizes { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserGender> UserGenders { get; set; }
        public DbSet<PetGender> PetGenders { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}