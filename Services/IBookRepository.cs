using LibraryExample.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public interface IBookRepository
    {
        IEnumerable<BookDto> GetBookForAuthor(int authorId);
        BookDto GetBookForAuthor(int authorId, int bookId);
    }
}
