using LibraryExample.api.Models;
using LibraryExample.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public IAuthorRepository _authorRepository { get; }

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public ActionResult<List<AuthorDto>> GetAuthors()
        {
            return _authorRepository.GetAuthors().ToList();
        }
    }
}
