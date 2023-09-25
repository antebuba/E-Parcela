using E_Parcela.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Parcela.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sadnice_Parcele>().HasKey(sp => new
            {
                sp.SadniceID,
                sp.ParceleID
            });

            modelBuilder.Entity<Sadnice_Parcele>().HasOne(p => p.Parcele).WithMany(sp => sp.Sadnice_Parcele).HasForeignKey(p => p.ParceleID);
            modelBuilder.Entity<Sadnice_Parcele>().HasOne(p => p.Sadnice).WithMany(sp => sp.Sadnice_Parcele).HasForeignKey(p => p.SadniceID);





            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Sadnice> Sadnice { get; set; }
        public DbSet<Parcele> Parcele { get; set; }
        public DbSet<Sadnice_Parcele> Sadnice_Parcele { get; set; }
        public DbSet<Suradnici> Suradnici { get; set; }
        public DbSet<Zaposlenici> Zaposlenici { get; set; }
    }
}
