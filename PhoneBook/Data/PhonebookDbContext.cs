using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Data
{
    public class PhonebookDbContext:DbContext
    {
        public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options)
            : base(options)
        { }

         public DbSet<PhoneBooks> PhonesBooks { get; set; }
        public DbSet<Entry> Entries { get; set; } 


    }
}
