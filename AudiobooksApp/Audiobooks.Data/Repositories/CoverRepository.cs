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
    public class CoverRepository : RepositoryBase<Cover, int>, ICoverRepository
    {
        public CoverRepository(BooksContext ctx) : base(ctx)
        {
        }
    }
}
