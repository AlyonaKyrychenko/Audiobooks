using Audiobooks.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Services
{
    public class FileStorage : IFileStorage
    {
        private const string BASE_PATH = @"G:\FileStorage";

        public void CreateArchive(string name, Stream stream)
        {
            using (var file = File.Create($"{BASE_PATH}\\Archives\\{name}"))
            {
                stream.CopyTo(file);
            }
        }

        public void CreateCover(string name, Stream stream)
        {
            using (var file = File.Create($"{BASE_PATH}\\Covers\\{name}"))
            {
                stream.CopyTo(file);
            }
        }

        public Stream GetArchive(string name)
        {
            var fileStream = File.OpenRead($"{BASE_PATH}\\Archives\\{name}");
            return new BinaryReader(fileStream).BaseStream;
        }

        public Stream GetCover(string name)
        {
            var fileStream = File.OpenRead($"{BASE_PATH}\\Covers\\{name}");
            return new BinaryReader(fileStream).BaseStream;
        }
    }
}
