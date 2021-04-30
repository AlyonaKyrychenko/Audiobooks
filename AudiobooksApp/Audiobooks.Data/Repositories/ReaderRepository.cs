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
    public class ReaderRepository : RepositoryBase<Reader, int>, IReaderRepository
    {
        public ReaderRepository(BooksContext ctx) : base(ctx)
        {
        }
    }
}
