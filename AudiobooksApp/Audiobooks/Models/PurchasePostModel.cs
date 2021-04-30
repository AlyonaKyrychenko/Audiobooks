using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class PurchasePostModel
    {
        public string CustomerId { get; set; }

        public string ArchivePath { get; set; }
        public int BookId { get; set; }
        public ICollection<BookViewModel> Books { get; set; }
    }
}