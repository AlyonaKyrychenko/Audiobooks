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
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository, IMapper mapper = null)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public void Create(GenreModel entity)
        {
            var book = _mapper.Map<Genre>(entity);

            _genreRepository.Create(book);
        }

        public void Delete(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var genre = _genreRepository.GetById(id);

            if (genre is null)
                throw new Exception("Genre not found");

            _genreRepository.Delete(genre);
        }

        public IReadOnlyCollection<GenreModel> GetAll()
        {
            var genre = _genreRepository.GetAll();
            var result = _mapper.Map<IReadOnlyCollection<GenreModel>>(genre);

            return result;
        }

        public IReadOnlyCollection<GenreModel> GetAll(string name)
        {
            var genre = _genreRepository.GetAll(x => x.Name.Contains(name));
            var result = _mapper.Map<IReadOnlyCollection<GenreModel>>(genre);

            return result;
        }

        public GenreModel GetById(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var genre = _genreRepository.GetById(id);
            var result = _mapper.Map<GenreModel>(genre);

            return result;
        }

        public void Update(GenreModel entity)
        {
            if (entity.Id == null)
                throw new ArgumentNullException(nameof(entity.Id));

            var genre = _genreRepository.GetById(entity.Id);

            if (genre is null)
                throw new Exception("Genre not found");

            genre.Name = entity.Name;

            _genreRepository.Update(genre);
        }
    }
}
