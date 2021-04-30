using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}