using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Common.Contracts
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
