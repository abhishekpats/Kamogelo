using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class PhoneBooks
    {
        public PhoneBooks()
        {
            Entries = new List<Entry>();
        }        
        [Key]
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
