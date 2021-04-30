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
    public class ArchiveRepository : RepositoryBase<Archive, int>, IArchiveRepository
    {
        public ArchiveRepository(BooksContext ctx) : base(ctx)
        {
        }
    }
}
