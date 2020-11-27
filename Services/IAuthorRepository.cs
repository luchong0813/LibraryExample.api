using LibraryExample.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<AuthorDto> GetAuthors();
        AuthorDto GetAuthorById(int authorId);
        bool IsAuthorExists(int authorId);

        void AddAuthor(AuthorDto author);
        void DeleteAuthor(AuthorDto author);
    }
}
