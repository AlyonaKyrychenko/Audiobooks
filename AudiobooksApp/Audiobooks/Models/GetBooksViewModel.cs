using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class GetBooksViewModel
    {
        public IReadOnlyCollection<BookViewModel> Books { get; set; }
    }
}