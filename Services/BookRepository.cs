using LibraryExample.api.Data;
using LibraryExample.api.Entities;
using LibraryExample.api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        #region old
        //public void AddBook(BookDto book)
        //{
        //    book.Id = LibraryMockData.Current.Books.Max(b => b.Id) + 1;
        //    LibraryMockData.Current.Books.Add(book);
        //}

        //public void DeleteBook(BookDto book)
        //{
        //    LibraryMockData.Current.Books.Remove(book);
        //}

        //public IEnumerable<BookDto> GetBookForAuthor(int authorId)
        //{
        //    return LibraryMockData.Current.Books.Where(b => b.AuthorId == authorId).ToList();
        //}

        //public BookDto GetBookForAuthor(int authorId, int bookId)
        //{
        //    return LibraryMockData.Current.Books.FirstOrDefault(b => b.AuthorId == authorId && b.Id == bookId);
        //}

        //public void UpdateBook(int authorId, int bookId, BookForUpdateDto book)
        //{
        //    var newbook = GetBookForAuthor(authorId, bookId);
        //    newbook.Title = book.Title;
        //    newbook.Description = book.Description;
        //    newbook.Pages = book.Pages;
        //}
        #endregion
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> GetBookAsync(int authorId, int bookId)
        {
            return await _dbContext.Set<Book>().SingleOrDefaultAsync(b => b.AuthorId == authorId && b.Id == bookId);
        }

        public Task<IEnumerable<Book>> GetBooksAsync(int authorId)
        {
            return Task.FromResult(_dbContext.Set<Book>().Where(b => b.AuthorId == authorId).AsEnumerable());
        }
    }
}
