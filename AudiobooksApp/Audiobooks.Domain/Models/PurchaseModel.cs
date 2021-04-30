using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public string ArchivePath { get; set; }
        public int BookId { get; set; }
        public ICollection<BookModel> Books { get; set; }
    }
}
