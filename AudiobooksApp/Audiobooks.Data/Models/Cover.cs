using Audiobooks.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Models
{
    public class Cover : IEntity<int>
    {
        public int Id { get; set; }
        public string FilePath { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
