using Audiobooks.Domain.Contracts;
using Audiobooks.Domain.Models;
using Audiobooks.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Audiobooks.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderService _readerService;
        private readonly IMapper _mapper;

        public ReaderController(IReaderService readerService, IMapper mapper)
        {
            _readerService = readerService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var reader = _readerService.GetAll();
            var readerVm = _mapper.Map<List<ReaderViewModel>>(reader);

            var data = new GetReadersViewModel
            {
                Readers = readerVm
            };

            return View(data);
        }

        //Не работает если изменить id на что-то другое
        [Route("GetAll/{id}")]
        public ActionResult GetAll(string id)
        {
            var reader = _readerService.GetAll(id);
            var readerVm = _mapper.Map<List<ReaderViewModel>>(reader);

            var data = new GetReadersViewModel
            {
                Readers = readerVm
            };

            return View(data);
        }

        [Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            var reader = _readerService.GetById(id);
            var vm = _mapper.Map<ReaderViewModel>(reader);

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReaderPostModel model)
        {
            var reader = _mapper.Map<ReaderModel>(model);

            _readerService.Create(reader);

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
            var reader = _readerService.GetById(id);
            reader.Name = name;
            _readerService.Update(reader);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            _readerService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}