using Audiobooks.Domain.Contracts;
using Audiobooks.Domain.Models;
using Audiobooks.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace Audiobooks.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var author = _authorService.GetAll();
            var authorsVm = _mapper.Map<List<AuthorViewModel>>(author);

            var data = new GetAuthorsViewModel
            { 
                Authors = authorsVm,
            };

            return View(data);
        }

        //Не работает если изменить id на что-то другое, хотя по логике там должно быть имя автора
        [Route("GetAll/{id}")]
        public ActionResult GetAll(string id)
        {
            var author = _authorService.GetAll(id);
            var authorsVm = _mapper.Map<List<AuthorViewModel>>(author);

            var data = new GetAuthorsViewModel
            {
                Authors = authorsVm,
            };

            return View(data);
        }

        [Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            var author = _authorService.GetById(id);

            var vm = _mapper.Map<AuthorViewModel>(author);

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorPostModel model)
        {
            var author = _mapper.Map<AuthorModel>(model);

            _authorService.Create(author);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [Route("Update/{id}")]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [Route("Update/{id}")]
        public ActionResult Update(int id, string name)
        {
            var author = _authorService.GetById(id);
            author.Name = name;
            _authorService.Update(author);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            _authorService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}