using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Algebra.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Adrese_upisanih> Adrese_upisanihh { get; set; }
        public virtual DbSet<Predavaci> Predavacii { get; set; }
        public virtual DbSet<Adresa_odrzavanja> Adresa_odrzavanjaa { get; set; }
        public virtual DbSet<Otvoreni_seminari> Otvoreni_seminarii { get; set; }
        public virtual DbSet<Predbiljezba> Predbiljezbaa { get; set; }
        public virtual DbSet<Seminari> Seminarii { get; set; }
        public virtual DbSet<Upisani> Upisanii { get; set; }
        public virtual DbSet<Adresepredavaca> Adrese_predavacaa { get; set; }
        public virtual DbSet<Upisi> Upisii { get; set; }
        public virtual DbSet<BrojUpisanih> BrojUpisanihh { get; set; }

        public virtual DbSet<UpisanihBroj> UpisanihBrojj { get; set; }
        
    }
}