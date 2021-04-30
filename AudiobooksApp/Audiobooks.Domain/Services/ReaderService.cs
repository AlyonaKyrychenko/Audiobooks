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
    public class ReaderService : IReaderService
    {
        private readonly IMapper _mapper;
        private readonly IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository genreRepository, IMapper mapper = null)
        {
            _readerRepository = genreRepository;
            _mapper = mapper;
        }

        public void Create(ReaderModel entity)
        {
            var book = _mapper.Map<Reader>(entity);

            _readerRepository.Create(book);
        }

        public void Delete(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var reader = _readerRepository.GetById(id);

            if (reader is null)
                throw new Exception("Reader not found");

            _readerRepository.Update(reader);
        }

        public IReadOnlyCollection<ReaderModel> GetAll()
        {
            var reader = _readerRepository.GetAll();
            var result = _mapper.Map<IReadOnlyCollection<ReaderModel>>(reader);

            return result;
        }

        public IReadOnlyCollection<ReaderModel> GetAll(string name)
        {
            var reader = _readerRepository.GetAll(x => x.Name.Contains(name));
            var result = _mapper.Map<IReadOnlyCollection<ReaderModel>>(reader);

            return result;
        }

        public ReaderModel GetById(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var reader = _readerRepository.GetById(id);
            var result = _mapper.Map<ReaderModel>(reader);

            return result;
        }

        public void Update(ReaderModel entity)
        {
            if (entity.Id == null)
                throw new ArgumentNullException(nameof(entity.Id));

            var reader = _readerRepository.GetById(entity.Id);

            if (reader is null)
                throw new Exception("Reader not found");

            reader.Name = entity.Name;

            _readerRepository.Update(reader);
        }
    }
}
