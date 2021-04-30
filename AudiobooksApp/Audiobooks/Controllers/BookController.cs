using Audiobooks.Domain.Contracts;
using Audiobooks.Domain.Models;
using Audiobooks.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Audiobooks.Controllers
{
    [RoutePrefix("Book")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IFileStorage _fileStorage;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper, IFileStorage fileStorage)
        {
            _bookService = bookService;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        public ActionResult Index()
        {
            var book = _bookService.GetAll();
            var booksVm = _mapper.Map<List<BookViewModel>>(book);

            var data = new GetBooksViewModel
            {
                Books = booksVm
            };

            return View(data);
        }

        //Не работает если изменить id на что-то другое
        [Route("GetAll/{id}")]
        public ActionResult GetAll(string id)
        {
            var book = _bookService.GetAll(id);
            var booksVm = _mapper.Map<List<BookViewModel>>(book);

            var data = new GetBooksViewModel
            {
                Books = booksVm
            };

            return View(data);
        }

        [Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            var vm = _mapper.Map<BookViewModel>(book);

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(BookPostModel model)
        {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var book = _mapper.Map<BookModel>(model);

            var createdBook = _bookService.CreateBook(book);

            return View(createdBook);
        }

        [HttpPost]
        public ActionResult AddArchive(BookPostModel model)
        {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var book = _mapper.Map<BookModel>(model);

            var addArchive = _bookService.CreateArchive(book);

            return View(addArchive);
        }

        [Authorize(Roles = "Admin")]
        [Route("Update/{id}")]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public ActionResult Update(int id, string name, decimal price, int readerId, int genreId)
        {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var book = _bookService.GetById(id);
            book.Name = name;
            book.Price = price;
            book.ReaderId = readerId;
            book.GenreId = genreId;
            _bookService.Update(book);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            _bookService.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Purchase()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult Purchase(PurchasePostModel model)
        {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var purchase = _mapper.Map<PurchaseModel>(model);
            purchase.CustomerId = userId;
            purchase.ArchivePath = model.ArchivePath;

            _bookService.Purchase(purchase);

            return RedirectToAction("ViewPurchasedBooks");
        }

        [Authorize(Roles = "User")]
        [Route("ViewPurchasedBooks")]
        public ActionResult ViewPurchasedBooks()
        {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var purchase = _bookService.ViewPurchasedBooks(userId);
            var purchaseVm = _mapper.Map<List<PurchaseViewModel>>(purchase);

            var data = new GetPurchaseViewModel
            {
                Purchases = purchaseVm
            };

            return View(data);
        }

        [Route("Cover/{id}")]
        [HttpPost]
        public ActionResult Cover(int id, HttpPostedFileBase uploadFile)
        {
            var fileName = $"BookId_{id}_{uploadFile.FileName}";
            var cover = new CoverViewModel
            {
                Id = id,
                FilePath = fileName,
                BookId = id
            };

            var coverMap = _mapper.Map<CoverModel>(cover);

            _fileStorage.CreateCover(fileName, uploadFile.InputStream);
            _bookService.AddCover(id, coverMap);

            return View("AddArchive", id);
        }

        [Route("GetCover/{id}")]
        public ActionResult GetCover(int id)
        {
            var photo = _bookService.GetCoverById(id);
            var file = _fileStorage.GetCover(photo.FilePath);

            return File(file, "image/jpg");
        }


        [Route("Archive/{id}")]
        [HttpPost]
        public ActionResult Arcive(int id, HttpPostedFileBase uploadFile)
        {
            var fileName = $"BookId_{id}_{uploadFile.FileName}";
            var archive = new ArchiveViewModel
            {
                Id = id,
                FilePath = fileName,
                BookId = id
            };

            var archiveMap = _mapper.Map<ArchiveModel>(archive);

            _fileStorage.CreateArchive(fileName, uploadFile.InputStream);
            _bookService.AddArchive(id, archiveMap);

            return RedirectToAction("Index");
        }

        [Route("GetArcive/{id}")]
        public ActionResult GetArcive(int id)
        {
            var archive = _bookService.GetArchiveById(id);
            var file = _fileStorage.GetArchive(archive.FilePath);

            return File(file, "application/zip");
        }
    }
}