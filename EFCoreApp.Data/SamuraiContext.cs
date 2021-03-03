using System;
using System.Diagnostics;
using EFCoreApp.Domian;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace EFCoreApp.Data
{
    public class SamuraiContext : DbContext
    {

        // Using Microsoft.Extensions.Logging.Console - version 2.2.0
        public static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
      
           // optionsBuilder
                //.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = EFCoreAppData; Trusted_Connection = True; ");

                optionsBuilder.UseSqlServer(
                    "Server = ADMINRG-121NNNJ\\SQLEXPRESS; Database = EFCoreAppData; Trusted_Connection = True; ",
                    b=> b.MinBatchSize(6)
                        
                )
                    .UseLoggerFactory(MyConsoleLoggerFactory)
                    .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });

            #region Extra Code


            // modelBuilder.Seed(); // Init Values 



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
            #endregion
        }

    }
}