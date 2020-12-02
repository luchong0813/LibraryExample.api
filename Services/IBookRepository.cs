using LibraryExample.api.Entities;
using LibraryExample.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public interface IBookRepository : IRepositoryBase<Book>, IRepositoryBase2<Book, int>
    {

        Task<IEnumerable<Book>> GetBooksAsync(int authorId);
        Task<Book> GetBookAsync(int authorId, int bookId);

        Task<bool> IsExistAsync(int authorId, int bookId);
    }
}
