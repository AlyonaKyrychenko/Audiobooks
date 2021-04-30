using Audiobooks.Data.Common;
using Audiobooks.Data.Contracts;
using Audiobooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Repositories
{
    public class GenreRepository : RepositoryBase<Genre, int>, IGenreRepository
    {
        public GenreRepository(BooksContext ctx) : base(ctx)
        {
        }
    }
}
