using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class GetGenresViewModel
    {
        public IReadOnlyCollection<GenreViewModel> Genres { get; set; }
    }
}