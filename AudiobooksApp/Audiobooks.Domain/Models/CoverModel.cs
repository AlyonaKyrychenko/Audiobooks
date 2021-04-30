using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Models
{
    public class CoverModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int BookId { get; set; }
    }
}
