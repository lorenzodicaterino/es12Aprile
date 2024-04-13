using Microsoft.EntityFrameworkCore;

namespace Esercitazione12Aprile_MarioKart.Model
{
    public class Es12AprileContext : DbContext
    {
        public Es12AprileContext(DbContextOptions<Es12AprileContext> options) : base(options)
        {

        }

        public DbSet<Squadra> Squadras { get; set; }
        public DbSet<Personaggio> Personaggios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Squadra>()
            .HasMany(e => e.Personaggi)
            .WithOne(e => e.SquadraRifNavigation)
            .HasForeignKey(e => e.SquadraRif);

            modelBuilder.Entity<Personaggio>()
            .HasOne(e => e.SquadraRifNavigation)
            .WithMany(e => e.Personaggi)
            .HasForeignKey(e => e.SquadraRif);
        }
    }
}
