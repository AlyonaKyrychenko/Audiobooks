using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Models
{
     public class ApplicationUser : IdentityUser
    {
        public ICollection<Author> Authors { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Reader> Readers { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
