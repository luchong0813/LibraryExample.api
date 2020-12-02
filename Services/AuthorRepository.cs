using LibraryExample.api.Data;
using LibraryExample.api.Entities;
using LibraryExample.api.Helpers;
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
        public AuthorRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<PageList<Author>> GetAllAsync(AuthorResourceParmeters parmeters)
        {
            var queryableAuthors = _dbContext.Set<Author>();

            return PageList<Author>.CreateAsync(queryableAuthors, parmeters.PageNumber, parmeters.PageSize);
        }
    }
}
