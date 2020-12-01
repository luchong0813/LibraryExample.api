using AutoMapper;
using LibraryExample.api.Entities;
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
        public IRepositoryWrapper _repositoryWrapper { get; }
        public IMapper _mapper { get; }

        public AuthorController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorsAsync()
        {
            var authors = (await _repositoryWrapper.Author.GetAllAsync()).OrderBy(author => author.Name);
            var authorDtoList = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return authorDtoList.ToList();
        }

        [HttpGet("{authorid}", Name = nameof(GetAuthorAsync))]
        public async Task<ActionResult<AuthorDto>> GetAuthorAsync(int authorid)
        {
            var author = await _repositoryWrapper.Author.GetByIdAsync(authorid);

            if (author == null)
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }


        [HttpPost]
        public async Task<ActionResult> CreateAuthorAsync(AuthorForCreationDto creationDto)
        {
            var author = _mapper.Map<Author>(creationDto);
            _repositoryWrapper.Author.Create(author);
            var result = await _repositoryWrapper.Author.SaveAsync();
            if (!result)
            {
                throw new Exception("创建资源失败");
            }
            var authorCreated = _mapper.Map<AuthorDto>(author);
            return CreatedAtRoute(nameof(GetAuthorAsync), new { authorId = authorCreated.Id }, authorCreated);
        }

        [HttpDelete("{authorId}")]
        public async Task<ActionResult> DeleteAuthorAsync(int authorId)
        {
            var author = await _repositoryWrapper.Author.GetByIdAsync(authorId);
            if (author == null)
            {
                return NotFound();
            }
            _repositoryWrapper.Author.Delete(author);
            var result = await _repositoryWrapper.Author.SaveAsync();
            if (!result)
            {
                throw new Exception("删除资源失败");
            }
            return Ok();
        }
    }
}
