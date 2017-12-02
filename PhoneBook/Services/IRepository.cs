using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public interface IRepository
    {
        IQueryable<Entry> GetAllEntries();
        void AddEntry(Entry entry);
    }
}
