using EFCoreApp.Data;
using EFCoreApp.Domian;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SomeUI
{
    class Program 
    {
        private static readonly SamuraiContext _context = new SamuraiContext();
        public static void Main(string[] args)
        {

            #region Debug EFCoreoperations

            //AddoneRecord();

            //AddMultipleRecords(); 

            //GetOneRecord(); 
            //GetOneRecordWithSpecficCondition(); 
            //GetOneRecordWirhitRelatedData();
            //GetOneRecordWithRelatedDataWithspecficCondition();

            //GetMultipleRecordsWithAllRelatedData();
            //GetMultipleRecordsWithRelateddatWithSpecficCondition();


            //GetMultipleRecordsOrderbySpecficProperty();
            //GetMultipleRecordsOrderbySpecficRelatedDataProperty();

            //GetdatafromMultiplerelationships();

            //ModifyOneRecord();
            //ModifyMultipleRecords();
           // ModifyOneRecordSpecficRelatedData();
            #endregion

            #region DebugEFCore_Trainig_Path

            

            #endregion

            Console.WriteLine(_context.ChangeTracker);
            Console.WriteLine("End Debuging ...");

            Console.ReadKey();
        }


        #region EFOperations
         
        public static void AddoneRecord()
        {
            var samurai = new Samurai()
            {
                Name = "Harry"
            };

            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
         
         
        public static void AddMultipleRecords()
        {
            List<Samurai> samuraias = new List<Samurai>()
            {
                new Samurai(){Name = "Mark Bens",SecretIdentity = new SecretIdentity(){RealName = "Hani"}},
                new Samurai(){Name = "George",SecretIdentity = new SecretIdentity(){RealName = "Reman"}},
                new Samurai(){Name = "Robert Jay ",SecretIdentity = new SecretIdentity(){RealName = "Sergi"}},
                new Samurai(){Name = "Leo Dan",SecretIdentity = new SecretIdentity(){RealName = "Ronlad"}}
            };

            _context.Samurais.AddRange(samuraias);
            _context.SaveChanges();
        }

        public static void GetOneRecord()
        {
            var samurai = _context.Samurais.FirstOrDefault();
        }

        public static void GetOneRecordWithSpecficCondition()
        {
            //var samurai = _context.Samurais.Find(1);

            //var samurai = _context.Samurais.Where(s => s.Id == 2).Single();
            //var samurai = _context.Samurais.Where(s => s.Name == "Harry").SingleOrDefault(); //Exception

            //var samurai = _context.Samurais.Where(s => s.Name == "Harry").FirstOrDefault(); // First Harry

            //var samurai = _context.Samurais.First();
            //var samurai = _context.Samurais.FirstOrDefault();
        }

        public static void GetOneRecordWirhitRelatedData()
        {
            //var samuraiQuotes = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 3);

            var samuraiAllRelatedData = _context.Samurais
                .Include(s => s.SecretIdentity)
                .Include(s => s.SamuraiBattles)
                .Include(s => s.Quotes)
                .FirstOrDefault(s => s.Id == 3);
        }

        public static void GetOneRecordWithRelatedDataWithspecficCondition()
        {
            var samuraiQoutes = _context.Samurais
                .Include(s => s.Quotes)
                .FirstOrDefault(s => s.Id == 3);

            var specficQoutes = samuraiQoutes.Quotes.Where(q => q.Text.StartsWith("H")).ToList();

        }

        public static void GetMultipleRecordsWithAllRelatedData()
        {
            var samuraisData = _context.Samurais
                .Include(s => s.SamuraiBattles)
                .Include(s => s.SecretIdentity)
                .Include(s => s.Quotes).ToList();
        }

        public static void GetMultipleRecordsWithRelateddatWithSpecficCondition()
        {
            var samuraisData = _context.Samurais
                .Include(s => s.SamuraiBattles)
                .Include(s => s.SecretIdentity)
                .Include(s => s.Quotes).ToList();

            

            //var quotes = _context.Quotes.Include(q =>q.Samurai).Where(q => q.Text.StartsWith("he")).ToList();
            //var samurias = quotes.Where(q => q.SamuraiId == 3).ToList();
        }

        public static void GetMultipleRecordsOrderbySpecficProperty()
        {
            var samurias = _context.Samurais.OrderBy(s => s.Id).ToList();
        }

        public static void GetMultipleRecordsOrderbySpecficRelatedDataProperty()
        {
            var samuriasData = _context.Samurais
                .Include(s => s.Quotes.OrderByDescending(q => q.SamuraiId)).ToList();
        }

        public static void ModifyOneRecord()
        {
            throw new NotImplementedException();
        }

        public static void ModifyMultipleRecords()
        {
            throw new NotImplementedException();
        }

        public static void ModifyOneRecordSpecficRelatedData()
        {
            var qoutes = _context.Quotes.Include(q => q.Samurai).ToList();

            var samuriaQuotes = qoutes.Where(s => s.SamuraiId == 3).ToList();

            var oneQuote = samuriaQuotes.SingleOrDefault(s => s.Text.StartsWith("Y"));
            oneQuote.Text = "You Can Do it";

            _context.SaveChanges();
        }

        public static void Getspecficnumberofrecordsfromtable()
        {
            var samurais = _context.Samurais.Take(5).ToList();
        }

        public static void Skipspecficnumberofrecordsintable()
        {
            var samurais = _context.Samurais.Skip(3).ToList();
        }


     
        #endregion
    }
}
