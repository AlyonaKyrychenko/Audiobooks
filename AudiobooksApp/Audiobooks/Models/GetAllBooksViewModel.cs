using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class GetAllBooksViewModel
    {
        public IReadOnlyCollection<AuthorViewModel> Authors { get; set; }
        public IReadOnlyCollection<GenreViewModel> Genres { get; set; }
        public IReadOnlyCollection<ReaderViewModel> Readers { get; set; }
        public IReadOnlyCollection<BookViewModel> Books { get; set; }
    }
}