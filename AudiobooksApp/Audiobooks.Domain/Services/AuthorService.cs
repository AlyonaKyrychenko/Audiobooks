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
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper = null)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public void Create(AuthorModel entity)
        {
            var author = _mapper.Map<Author>(entity);

            _authorRepository.Create(author);
        }

        public void Delete(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var author = _authorRepository.GetById(id);

            if (author is null)
                throw new Exception("Author not found");

            _authorRepository.Delete(author);
        }

        public IReadOnlyCollection<AuthorModel> GetAll()
        {
            var author = _authorRepository.GetAll();
            var result = _mapper.Map<IReadOnlyCollection<AuthorModel>>(author);

            return result;
        }

        public IReadOnlyCollection<AuthorModel> GetAll(string name)
        {
            var author = _authorRepository.GetAll(x => x.Name.Contains(name));
            var result = _mapper.Map<IReadOnlyCollection<AuthorModel>>(author);

            return result;
        }

        public AuthorModel GetById(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var author = _authorRepository.GetById(id);
            var result = _mapper.Map<AuthorModel>(author);

            return result;
        }

        public void Update(AuthorModel entity)
        {
            if (entity.Id == null)
                throw new ArgumentNullException(nameof(entity.Id));

            var author = _authorRepository.GetById(entity.Id);

            if (author is null)
                throw new Exception("Author not found");

            author.Name = entity.Name;

            _authorRepository.Update(author);
        }
    }
}
