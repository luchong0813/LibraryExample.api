using LibraryExample.api.Data;
using LibraryExample.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<BookDto> GetBookForAuthor(int authorId)
        {
            return LibraryMockData.Current.Books.Where(b => b.AuthorId == authorId).ToList();
        }

        public BookDto GetBookForAuthor(int authorId, int bookId)
        {
            return LibraryMockData.Current.Books.FirstOrDefault(b => b.AuthorId == authorId && b.Id == bookId);
        }
    }
}
