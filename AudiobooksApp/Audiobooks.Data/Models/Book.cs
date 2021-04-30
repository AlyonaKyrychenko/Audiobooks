using Audiobooks.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Models
{
    public class Book : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ArchivePath { get; set; }

        public int ArchiveId { get; set; }
        public ICollection<Archive> Archives { get; set; }

        public int CoverId { get; set; }
        public ICollection<Cover> Covers { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
