using LibraryExample.api.Entities;
using LibraryExample.api.Helpers;
using LibraryExample.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public interface IAuthorRepository : IRepositoryBase<Author>, IRepositoryBase2<Author, int>
    {
        Task<PageList<Author>> GetAllAsync(AuthorResourceParmeters parmeters);
    }
}
