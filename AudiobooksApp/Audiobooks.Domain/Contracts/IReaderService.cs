using Audiobooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Contracts
{
    public interface IReaderService
    {
        ReaderModel GetById(int id);
        IReadOnlyCollection<ReaderModel> GetAll();
        IReadOnlyCollection<ReaderModel> GetAll(string name);
        void Create(ReaderModel entity);
        void Update(ReaderModel entity);
        void Delete(int id);
    }
}
