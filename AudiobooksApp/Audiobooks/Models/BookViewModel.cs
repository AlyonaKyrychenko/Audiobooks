using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IReadOnlyCollection<int> CoverIds { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int ReaderId { get; set; }
    }
}