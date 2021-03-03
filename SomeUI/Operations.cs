using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreApp.Data;
using EFCoreApp.Domian;
using Microsoft.EntityFrameworkCore;

namespace SomeUI
{
    public static class Operations
    {
        private static readonly SamuraiContext _context = new SamuraiContext();
        public static void AddQoutesWhileTracked()
        {
            var samurai = _context.Samurais.First();

            var quote = new Quote()
            {
                Text = "Im Tracked Entity"
            };

            samurai.Quotes.Add(quote);

            _context.SaveChanges();


        }

        public static void AddQoutesWhileNotTracked(int SamuraiID)
        {
            var samurai = _context.Samurais.First();

            var quote = new Quote()
            {
                Text = "Im Not Tracked Entity",
                SamuraiId = SamuraiID // Pass the ForignKey
            };

            using (var newContext = new SamuraiContext())
            {
                newContext.Quotes.Add(quote);
                //newContext.Entry(quote).State = EntityState.Added;
                newContext.SaveChanges();
            }

        }

        public static void RelatedDataWithProjaction()
        {
            var samurai = _context.Samurais.Select(s => new {s.Id, s.Name}).ToList();

            var samuriQoute = _context.Samurais.Select(s => new {Id = s.Id, SamuraiName = s.Name, Qoutes = s.Quotes})
                .ToList();

            //Issue
            var samuriSpecficQoute = _context.Samurais
                .Select(s => new {s.Name, Quotes = s.Quotes.Where(q => q.Text.StartsWith("Hello"))}).ToList();

            //Will Attach Quotes to Samurai
            var samurais = _context.Samurais.ToList();
            var quotes = _context.Quotes.Where(q => q.Text.StartsWith("Hello")).ToList();
        }

        public static void FilteringWithRelatedData()
        {
            var samurais = _context.Samurais.Where(s => s.Quotes.Any(q => q.Text.Contains("hi"))).ToList();
        }
    }
}
