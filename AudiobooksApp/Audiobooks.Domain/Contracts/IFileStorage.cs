using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Domain.Contracts
{
    public interface IFileStorage
    {
        void CreateCover(string name, Stream stream);
        Stream GetCover(string name);
        void CreateArchive(string name, Stream stream);
        Stream GetArchive(string name);
    }
}
