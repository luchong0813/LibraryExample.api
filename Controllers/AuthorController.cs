using LibraryExample.api.Models;
using LibraryExample.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Controllers
{
    
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public IAuthorRepository _authorRepository { get; }

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public ActionResult<List<AuthorDto>> GetAuthors()
        {
            return _authorRepository.GetAuthors().ToList();
        }

        [HttpGet("{authorid}", Name = nameof(GetAuthor))]
        public ActionResult<AuthorDto> GetAuthor(int authorid)
        {
            var author = _authorRepository.GetAuthorById(authorid);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }


        [HttpPost]
        public IActionResult AddAuthor(AuthorForCreationDto creationDto)
        {
            var authorDto = new AuthorDto
            {
                Name = creationDto.Name,
                Age = creationDto.Age,
                Email = creationDto.Email
            };
            _authorRepository.AddAuthor(authorDto);
            return CreatedAtRoute(nameof(GetAuthor), new { authorId = authorDto.Id }, authorDto);
        }

        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            var author = _authorRepository.GetAuthorById(authorId);
            if (author == null)
            {
                return NotFound();
            }
            _authorRepository.DeleteAuthor(author);
            return NoContent();
        }
    }
}
