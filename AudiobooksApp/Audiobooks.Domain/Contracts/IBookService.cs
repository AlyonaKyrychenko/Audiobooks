using Audiobooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Contracts
{
    public interface IBookService
    {
        BookModel GetById(int id);
        IReadOnlyCollection<BookModel> GetAll();
        IReadOnlyCollection<BookModel> GetAll(string name);
        void Create(BookModel entity);
        void Update(BookModel entity);
        void Delete(int id);

        void Purchase(PurchaseModel entity);
        IReadOnlyCollection<PurchaseModel> ViewPurchasedBooks(string userId);

        void AddCover(int id, CoverModel cover);
        CoverModel GetCoverById(int id);
        int CreateBook(BookModel entity);

        void AddArchive(int id, ArchiveModel entity);
        ArchiveModel GetArchiveById(int id);
        int CreateArchive(BookModel entity);
    }
}
