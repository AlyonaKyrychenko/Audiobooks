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
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var genre = _genreService.GetAll();
            var genresVm = _mapper.Map<List<GenreViewModel>>(genre);

            var data = new GetGenresViewModel
            {
                Genres = genresVm
            };

            return View(data);
        }

        //Не работает если изменить id на что-то другое
        [Route("GetAll/{id}")]
        public ActionResult GetAll(string id)
        {
            var genre = _genreService.GetAll(id);
            var genresVm = _mapper.Map<List<GenreViewModel>>(genre);

            var data = new GetGenresViewModel
            {
                Genres = genresVm
            };

            return View(data);
        }

        [Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            var genre = _genreService.GetById(id);
            var vm = _mapper.Map<GenreViewModel>(genre);

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenrePostModel model)
        {
            var genre = _mapper.Map<GenreModel>(model);

            _genreService.Create(genre);

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
            var genre = _genreService.GetById(id);
            genre.Name = name;
            _genreService.Update(genre);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            _genreService.Delete(id);

            return RedirectToAction("Index");
        }

    }
}