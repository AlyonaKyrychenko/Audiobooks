using Audiobooks.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Models
{
    public class Purchase : IEntity<int>
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }
        public ICollection<ApplicationUser> Customer { get; set; }

        public string ArchivePath { get; set; }
        public int BookId { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
