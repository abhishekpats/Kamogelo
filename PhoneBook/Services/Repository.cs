using PhoneBook.Data;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class Repository : IRepository
    {
        private PhonebookDbContext _context;

        public Repository(PhonebookDbContext context)
        {
            _context = context;
        }

        public void AddEntry(Entry entry)
        {
            _context.Entries.Add(entry);
            _context.SaveChanges();
        }

        public IQueryable<Entry> GetAllEntries()
        {
            return _context.Entries;
        }
    }
}
