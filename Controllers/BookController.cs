using AutoMapper;
using LibraryExample.api.Models;
using LibraryExample.api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryExample.api.Filters;
using LibraryExample.api.Entities;

namespace LibraryExample.api.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    [ServiceFilter(typeof(CheckAutoExistFilterAttribute))]
    public class BookController : ControllerBase
    {
        public IRepositoryWrapper _repositoryWrapper { get; }
        public Mapper _mapper { get; }

        public BookController(IRepositoryWrapper repositoryWrapper, Mapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync(int authorId)
        {
            var books = await _repositoryWrapper.Book.GetBooksAsync(authorId);
            var booksDtoList = _mapper.Map<IEnumerable<BookDto>>(books);
            return booksDtoList.ToList();
        }

        [HttpGet("{bookId}", Name = nameof(GetBooksAsync))]
        public async Task<ActionResult<BookDto>> GetBooksAsync(int authorId, int bookId)
        {
            var book = await _repositoryWrapper.Book.GetBookAsync(authorId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            return _mapper.Map<BookDto>(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(int authorId, BookForCreationDto creationDto)
        {
            var book = _mapper.Map<Book>(creationDto);
            book.AuthorId = authorId;
            _repositoryWrapper.Book.Create(book);
            if (!await _repositoryWrapper.Book.SaveAsync())
            {
                throw new Exception("创建资源失败");
            }
            var bookDto = _mapper.Map<BookDto>(book);
            return CreatedAtRoute(nameof(GetBooksAsync), new { bookId = bookDto.Id }, bookDto);
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookAsync(int authorId, int bookId)
        {
            var book = await _repositoryWrapper.Book.GetBookAsync(authorId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            _repositoryWrapper.Book.Delete(book);
            if (!await _repositoryWrapper.Book.SaveAsync())
            {
                throw new Exception("删除资源失败");
            }
            return Ok();
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBookAsync(int authorId, int bookId, BookForUpdateDto updatebook)
        {
            var book = await _repositoryWrapper.Book.GetBookAsync(authorId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(updatebook, book, typeof(BookForUpdateDto), typeof(Book));
            _repositoryWrapper.Book.Update(book);
            if (!await _repositoryWrapper.Book.SaveAsync())
            {
                throw new Exception("更新资源失败");
            }
            return Ok();
        }

        [HttpPatch("{bookId}")]
        public async Task<IActionResult> PartiallyUpdateBook(int authorId, int bookId, JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            var book = await _repositoryWrapper.Book.GetBookAsync(authorId, bookId);
            if (book == null)
            {
                return NotFound();
            }
            var bookUpdateDto = _mapper.Map<BookForUpdateDto>(book);
            patchDocument.ApplyTo(bookUpdateDto, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(bookUpdateDto, book, typeof(BookForUpdateDto), typeof(Book));
            _repositoryWrapper.Book.Update(book);
            if (!await _repositoryWrapper.Book.SaveAsync())
            {
                throw new Exception("更新资源失败");
            }
            return Ok();
        }

    }
}
