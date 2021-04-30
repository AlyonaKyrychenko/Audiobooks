using Audiobooks.Data.Contracts;
using Audiobooks.Data.Models;
using Audiobooks.Domain.Contracts;
using Audiobooks.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Services
{
    public class BookService: IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ICoverRepository _coverRepository;
        private readonly IArchiveRepository _archiveRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper, IPurchaseRepository purchaseRepository, ICoverRepository coverRepository, IArchiveRepository archiveRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
            _coverRepository = coverRepository;
            _archiveRepository = archiveRepository;
        }

        public void Create(BookModel entity)
        {
            var book = _mapper.Map<Book>(entity);

            _bookRepository.Create(book);
        }

        public void Delete(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var book = _bookRepository.GetById(id);

            if (book is null)
                throw new Exception("Book not found");

            _bookRepository.Delete(book);
        }

        public IReadOnlyCollection<BookModel> GetAll()
        {
            var book = _bookRepository.GetAll();
            var result = _mapper.Map<IReadOnlyCollection<BookModel>>(book);

            return result;
        }

        public IReadOnlyCollection<BookModel> GetAll(string name)
        {
            var book = _bookRepository.GetAll(x => x.Name.Contains(name));
            var result = _mapper.Map<IReadOnlyCollection<BookModel>>(book);

            return result;
        }

        public BookModel GetById(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var book = _bookRepository.GetById(id);
            var result = _mapper.Map<BookModel>(book);

            return result;
        }

        public void Update(BookModel entity)
        {
            if (entity.Id == null)
                throw new ArgumentNullException(nameof(entity.Id));

            var book = _bookRepository.GetById(entity.Id);

            if (book is null)
                throw new Exception("Book not found");

            book.Name = entity.Name;

            _bookRepository.Update(book);
        }

        public void Purchase(PurchaseModel entity)
        {
            var purchase = _mapper.Map<Purchase>(entity);
            purchase.CustomerId = entity.CustomerId;
            purchase.ArchivePath = entity.ArchivePath;

            _purchaseRepository.Create(purchase);
        }

        public IReadOnlyCollection<PurchaseModel> ViewPurchasedBooks(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(nameof(userId));

            var purchase = _purchaseRepository.GetAll(x => x.CustomerId == userId);
            var result = _mapper.Map<IReadOnlyCollection<PurchaseModel>>(purchase);

            return result;
        }

        public void AddCover(int id, CoverModel cover)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var book = _bookRepository.GetById(id);

            if (book is null)
                throw new Exception("Book not found");

            book.CoverId = cover.Id;

            _bookRepository.Update(book);

            var coverMap = _mapper.Map<Cover>(cover);

            _coverRepository.Create(coverMap);
        }

        public CoverModel GetCoverById(int id)
        {
            var cover = _bookRepository.GetCoverById(id);

            return _mapper.Map<CoverModel>(cover);
        }

        public int CreateBook(BookModel entity)
        {
            var book = _mapper.Map<Book>(entity);

            _bookRepository.Create(book);

            return book.Id;
        }

        public void AddArchive(int id, ArchiveModel entity)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var book = _bookRepository.GetById(id);

            if (book is null)
                throw new Exception("Book not found");

            book.ArchivePath = entity.FilePath;

            _bookRepository.Update(book);

            var archiveMap = _mapper.Map<Archive>(entity);

            _archiveRepository.Create(archiveMap);
        }

        public ArchiveModel GetArchiveById(int id)
        {
            var cover = _bookRepository.GetCoverById(id);

            return _mapper.Map<ArchiveModel>(cover);
        }

        public int CreateArchive(BookModel entity)
        {
            var book = _mapper.Map<Book>(entity);

            _bookRepository.Create(book);

            return book.Id;
        }
    }
}
