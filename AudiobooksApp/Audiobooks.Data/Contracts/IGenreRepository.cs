using Audiobooks.Data.Common.Contracts;
using Audiobooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Contracts
{
    public interface IGenreRepository : IRepositoryBase<Genre, int>
    {
    }
}
