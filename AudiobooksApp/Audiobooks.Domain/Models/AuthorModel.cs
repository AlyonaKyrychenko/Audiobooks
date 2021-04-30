using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
