using Microsoft.EntityFrameworkCore;
using Proyecto_MVC.Models;
namespace Proyecto_MVC.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones
            modelBuilder.Entity<Ventas>()
                .HasOne<Clientes>()
                .WithMany()
                .HasForeignKey(v => v.ClienteId);
        }
    }
}