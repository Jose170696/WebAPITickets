using Microsoft.EntityFrameworkCore;
using WebAPITickets.Models;

namespace WebAPITickets.Database
{
    public class ContextoBD: DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options): base(options){}
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasKey(x => x.ro_identificador);
        }
    }
}
