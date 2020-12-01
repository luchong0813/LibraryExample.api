using LibraryExample.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IAuthorRepository _authorRepository = null;
        private IBookRepository _bookRepository = null;

        public RepositoryWrapper(LibrayDbContext librayDbContext)
        {
            _librayDbContext = librayDbContext;
        }

        public IBookRepository Book => _bookRepository ?? new BookRepository(_librayDbContext);

        public IAuthorRepository Author => _authorRepository ?? new AuthorRepository(_librayDbContext);

        public LibrayDbContext _librayDbContext { get;  }
    }
}
