using Audiobooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Contracts
{
    public interface IAuthorService
    {
        AuthorModel GetById(int id);
        IReadOnlyCollection<AuthorModel> GetAll();
        IReadOnlyCollection<AuthorModel> GetAll(string name);
        void Create(AuthorModel entity);
        void Update(AuthorModel entity);
        void Delete(int id);
    }
}
