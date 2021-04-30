using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CoverId { get; set; }
        public ICollection<CoverModel> Covers { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int ReaderId { get; set; }
    }
}
