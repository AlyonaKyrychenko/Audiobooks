using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class CoverViewModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int BookId { get; set; }
    }
}