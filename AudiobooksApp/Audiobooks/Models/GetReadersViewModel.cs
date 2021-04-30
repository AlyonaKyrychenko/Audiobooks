using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class GetReadersViewModel
    {
        public IReadOnlyCollection<ReaderViewModel> Readers { get; set; }
    }
}