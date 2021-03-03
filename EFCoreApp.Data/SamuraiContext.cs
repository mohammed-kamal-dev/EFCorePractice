using System;
using System.Diagnostics;
using EFCoreApp.Domian;
using Microsoft.EntityFrameworkCore;
    



namespace EFCoreApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
      
            optionsBuilder
                .UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = EFCoreAppData; Trusted_Connection = True; ")
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });

            //Seeding DataBase
            // modelBuilder.Seed(); // Init Values 

            //Add Shadow Property
            //modelBuilder.Entity<Samurai>().Property<DateTime>("LastAdded");


            //Mapping nullable foreign key SamuraiId 
            //modelBuilder.Entity<Samurai>()
            //    .HasOne(s => s.SecretIdentity)
            //    .WithOne(i => i.Samurai).HasForeignKey<SecretIdentity>("SamuraiId");

            //Mapping unconventionally named foreign key property
            // Special syntax (parameterless WithOne, HFK<SecretIdentity>
            // are because I have no Samurai navigation property
            //modelBuilder.Entity<Samurai>()
            //    .HasOne(i => i.SecretIdentity)
            //    .WithOne()
            //    .HasForeignKey<SecretIdentity>(i => i.SamuraiFK);
        }

    }
}