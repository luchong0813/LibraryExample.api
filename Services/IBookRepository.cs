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
        //IEnumerable<BookDto> GetBookForAuthor(int authorId);
        //BookDto GetBookForAuthor(int authorId, int bookId);
        //void AddBook(BookDto book);
        //void DeleteBook(BookDto book);
        //void UpdateBook(int authorId,int bookId,BookForUpdateDto book);

        Task<IEnumerable<Book>> GetBooksAsync(int authorId);
        Task<Book> GetBookAsync(int authorId, int bookId);
    }
}
