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
        public byte[] Avatar { get; set; }

        [MaxLength(35)]
        public string FirstName { get; set; }

        [MaxLength(35)]
        public string Surname { get; set; }

        public DateTime? Birthdate { get; set; }
        //Trocar string gender por referencia ao banco

        public char Gender { get; set; }

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
        //Trocar as strings de cidade e estado por referencia ao banco

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }
        //Adicionar redes sociais
        public bool? FormOk { get; set; } //Flag para saber se a pessoa esta com o cadastro ok
        public bool? Deleted { get; set; }
        //Adicionar funcao de reportar
        //Adicionar data de criação
        //Adicionar ultima vez visto
        //adicionar homepage

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