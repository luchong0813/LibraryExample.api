using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public interface IRepositoryWrapper
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
    }
}
