using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class GetAuthorsViewModel
    {
        public IReadOnlyCollection<AuthorViewModel> Authors { get; set; }

    }
}