using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneBooks PhoneBook { get; set; }
    }
}
