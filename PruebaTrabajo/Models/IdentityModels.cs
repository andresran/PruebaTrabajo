using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PruebaTrabajo.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserRoles");
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<proyectos>().ToTable("proyectos");
            modelBuilder.Entity<HistoriaUsuario>().ToTable("HistoriaUsuario");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");


            // toda historia de desarrollo se relaciona con un ticket, todo ticket tiene una historia de ususario
            modelBuilder.Entity<HistoriaUsuario>().HasRequired(x => x.Ticket).WithRequiredPrincipal(t => t.HistoriaUsuario);




        }

        public System.Data.Entity.DbSet<PruebaTrabajo.Models.Empresa> Empresas { get; set; }

        public System.Data.Entity.DbSet<PruebaTrabajo.Models.proyectos> proyectos { get; set; }

        public System.Data.Entity.DbSet<PruebaTrabajo.Models.HistoriaUsuario> HistoriaUsuarios { get; set; }

        public System.Data.Entity.DbSet<PruebaTrabajo.Models.Ticket> Tickets { get; set; }
    }
}