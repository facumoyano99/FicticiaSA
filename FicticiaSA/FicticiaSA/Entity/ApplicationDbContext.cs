using FicticiaSA.Models;
using Microsoft.EntityFrameworkCore;

namespace FicticiaSA.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Persona> Personas { get; set; }
    }
}
