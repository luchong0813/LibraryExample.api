using LibraryExample.api.Models;
using LibraryExample.api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Controllers
{
    [Route("api/authors/{authorId}/books")]
    public class BookController : Controller
    {
        public IBookRepository _bookRepository { get; }
        public IAuthorRepository _authorRepository { get; }

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public ActionResult<List<BookDto>> GetBooks(int authorId)
        {
            //如果查询的作者不存在
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            return _bookRepository.GetBookForAuthor(authorId).ToList();
        }

        [HttpGet("{bookId}", Name = nameof(GetBook))]
        public ActionResult<BookDto> GetBook(int authorId, int bookId)
        {
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            var book = _bookRepository.GetBookForAuthor(authorId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public IActionResult AddBook(int authorId, BookForCreationDto creationDto)
        {
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            var newBook = new BookDto
            {
                Title = creationDto.Title,
                Pages = creationDto.Pages,
                Description = creationDto.Description,
                AuthorId = authorId
            };
            _bookRepository.AddBook(newBook);
            return CreatedAtRoute(nameof(GetBook), new { authorId = authorId, bookId = newBook.Id }, newBook);
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int authorId, int bookId)
        {
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            var book = _bookRepository.GetBookForAuthor(authorId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.DeleteBook(book);
            return NoContent();
        }

        [HttpPut("{bookId}")]
        public IActionResult UpdateBook(int authorId, int bookId, BookForUpdateDto updatebook)
        {
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            var book = _bookRepository.GetBookForAuthor(authorId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.UpdateBook(authorId, bookId, updatebook);
            return Ok();
        }

        [HttpPatch("{bookId}")]
        public IActionResult PartiallyUpdateBook(int authorId,int bookId,JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            var book=_bookRepository.GetBookForAuthor(authorId,bookId);
            if (book==null)
            {
                return NotFound();
            }
            var bookToPatch=new BookForUpdateDto
            {
                Title=book.Title,
                Description=book.Description,
                Pages=book.Pages
            };
            patchDocument.ApplyTo(bookToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookRepository.UpdateBook(authorId,bookId,bookToPatch);
            return Ok();
        }

    }
}
