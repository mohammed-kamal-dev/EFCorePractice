using EFCoreApp.Domian;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreApp.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Add 10 Samurai 
            modelBuilder.Entity<Samurai>().HasData(
                new Samurai() { Id = 1 , Name =""},
                new Samurai() { Id = 2 , Name =""},
                new Samurai() { Id = 3 , Name =""},
                new Samurai() { Id = 4 , Name =""},
                new Samurai() { Id = 5 , Name =""},
                new Samurai() { Id = 6 , Name =""},
                new Samurai() { Id = 7 , Name =""},
                new Samurai() { Id = 8 , Name =""},
                new Samurai() { Id = 9 , Name =""},
                new Samurai() { Id = 10 , Name =""}
                );

            //Add samurai Real Name
            modelBuilder.Entity<SecretIdentity>().HasData(
                new SecretIdentity() { Id = 1 , RealName ="" , SamuraiId = 1},
                new SecretIdentity() { Id = 2 , RealName ="" , SamuraiId = 2},
                new SecretIdentity() { Id = 3 , RealName ="" , SamuraiId = 3},
                new SecretIdentity() { Id = 4 , RealName ="" , SamuraiId = 4},
                new SecretIdentity() { Id = 5 , RealName ="" , SamuraiId = 5},
                new SecretIdentity() { Id = 6 , RealName ="" , SamuraiId = 6},
                new SecretIdentity() { Id = 7 , RealName ="" , SamuraiId = 7},
                new SecretIdentity() { Id = 8 , RealName ="" , SamuraiId = 8},
                new SecretIdentity() { Id = 9 , RealName ="" , SamuraiId = 9},
                new SecretIdentity() { Id = 10 , RealName ="" , SamuraiId = 10}
                );

            //ADD 16 Samurai Quotes
            modelBuilder.Entity<Quote>().HasData(
                new Quote() { Id = 1 , SamuraiId = 1 , Text = ""},
                new Quote() { Id = 2 , SamuraiId = 1 , Text = ""},
                new Quote() { Id = 3 , SamuraiId = 1 , Text = ""},
                new Quote() { Id = 4 , SamuraiId = 2 , Text = ""},
                new Quote() { Id = 5 , SamuraiId = 3 , Text = ""},
                new Quote() { Id = 6 , SamuraiId = 4 , Text = ""},
                new Quote() { Id = 7 , SamuraiId = 4 , Text = ""},
                new Quote() { Id = 8 , SamuraiId = 5 , Text = ""},
                new Quote() { Id = 9 , SamuraiId = 6 , Text = ""},
                new Quote() { Id = 10 , SamuraiId = 7 , Text = ""},
                new Quote() { Id = 11 , SamuraiId = 8 , Text = ""},
                new Quote() { Id = 12 , SamuraiId = 9 , Text = ""},
                new Quote() { Id = 13 , SamuraiId = 9 , Text = ""},
                new Quote() { Id = 14 , SamuraiId = 10 , Text = ""},
                new Quote() { Id = 15 , SamuraiId = 10 , Text = ""},
                new Quote() { Id = 16 , SamuraiId = 7 , Text = ""}
                );

            //Add 10 Battles
            modelBuilder.Entity<Battle>().HasData(
                new Battle() { Id =1 , Name ="" , StartDate = DateTime.ParseExact("2-10-1988", "d-M-yyyy",null) , EndDate = DateTime.Parse("10-10-1998") },
                new Battle() { Id =2 , Name ="" , StartDate = DateTime.ParseExact("4-8-1980", "d-M-yyyy",null) , EndDate = DateTime.Parse("2-9-1980") },
                new Battle() { Id =3 , Name ="" , StartDate = DateTime.ParseExact("22-9-1981", "d-M-yyyy",null) , EndDate = DateTime.Parse("28-9-1998") },
                new Battle() { Id =4 , Name ="" , StartDate = DateTime.ParseExact("2-1-1975", "d-M-yyyy",null) , EndDate = DateTime.Parse("10-1-1975") },
                new Battle() { Id =5 , Name ="" , StartDate = DateTime.ParseExact("10-12-1973", "d-M-yyyy",null) , EndDate = DateTime.Parse("20-12-1973") },
                new Battle() { Id =6 , Name ="" , StartDate = DateTime.ParseExact("26-11-1978", "d-M-yyyy",null) , EndDate = DateTime.Parse("2-12-1978") },
                new Battle() { Id =7 , Name ="" , StartDate = DateTime.ParseExact("2-1-1988", "d-M-yyyy",null) , EndDate = DateTime.Parse("21-1-1998") },
                new Battle() { Id =8 , Name ="" , StartDate = DateTime.ParseExact("20-4-1950", "d-M-yyyy",null) , EndDate = DateTime.Parse("1-5-1950") },
                new Battle() { Id =9 , Name ="" , StartDate = DateTime.ParseExact("2-7-1940", "d-M-yyyy",null) , EndDate = DateTime.Parse("23-7-1940") },
                new Battle() { Id =10 , Name ="" , StartDate = DateTime.ParseExact("2-1-1970", "d-M-yyyy",null) , EndDate = DateTime.Parse("6-1-1970") }

                );

            //Add Samurai Battle
            modelBuilder.Entity<SamuraiBattle>().HasData(
                new SamuraiBattle() { BattleId = 1 , SamuraiId = 1},
                new SamuraiBattle() { BattleId = 1 , SamuraiId = 5},
                new SamuraiBattle() { BattleId = 1 , SamuraiId = 7},
                new SamuraiBattle() { BattleId = 2 , SamuraiId = 4},
                new SamuraiBattle() { BattleId = 2 , SamuraiId = 4},
                new SamuraiBattle() { BattleId = 3 , SamuraiId = 8},
                new SamuraiBattle() { BattleId = 3 , SamuraiId = 6},
                new SamuraiBattle() { BattleId = 8 , SamuraiId = 9},
                new SamuraiBattle() { BattleId = 7 , SamuraiId = 9},
                new SamuraiBattle() { BattleId = 10 , SamuraiId = 3},
                new SamuraiBattle() { BattleId = 10 , SamuraiId = 3},
                new SamuraiBattle() { BattleId = 6 , SamuraiId = 2},
                new SamuraiBattle() { BattleId = 4 , SamuraiId = 2}
                );
        }
    }
}
