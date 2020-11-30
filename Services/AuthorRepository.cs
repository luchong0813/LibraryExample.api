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
    public class AuthorRepository : RepositoryBase<Author, int>, IAuthorRepository
    {
        #region old
        //public void AddAuthor(AuthorDto author)
        //{
        //    author.Id = LibraryMockData.Current.Authors.Max(a => a.Id) + 1;
        //    LibraryMockData.Current.Authors.Add(author);
        //}

        //public void DeleteAuthor(AuthorDto author)
        //{
        //    LibraryMockData.Current.Books.RemoveAll(b => b.AuthorId == author.Id);
        //    LibraryMockData.Current.Authors.Remove(author);
        //}

        //public AuthorDto GetAuthorById(int authorId)
        //{
        //    return LibraryMockData.Current.Authors.FirstOrDefault(a => a.Id == authorId);
        //}

        //public IEnumerable<AuthorDto> GetAuthors()
        //{
        //    return LibraryMockData.Current.Authors;
        //}

        //public bool IsAuthorExists(int authorId)
        //{
        //    return LibraryMockData.Current.Authors.Any(a => a.Id == authorId);
        //}
        #endregion
        public AuthorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
