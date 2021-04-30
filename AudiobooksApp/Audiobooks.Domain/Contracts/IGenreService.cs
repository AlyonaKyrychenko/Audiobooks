using Audiobooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Contracts
{
    public interface IGenreService
    {
        GenreModel GetById(int id);
        IReadOnlyCollection<GenreModel> GetAll();
        IReadOnlyCollection<GenreModel> GetAll(string name);
        void Create(GenreModel entity);
        void Update(GenreModel entity);
        void Delete(int id);
    }
}
