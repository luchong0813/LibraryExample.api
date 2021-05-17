using AutoMapper;
using LibraryExample.api.Entities;
using LibraryExample.api.Models;
using LibraryExample.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryExample.api.Helpers;
using Newtonsoft.Json;

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

        [HttpGet(Name = nameof(GetAuthorsAsync))]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorsAsync([FromQuery] AuthorResourceParmeters parmeters)
        {
            var pageList = await _repositoryWrapper.Author.GetAllAsync(parmeters);
            var paginationMetadata = new
            {
                totalCount = pageList._totalCount,
                pageSize = pageList._pageSize,
                currentPage = pageList._pageNumber,
                totalPages = pageList.TotalPage,
                previousePageLink = pageList.HasPrevious ? Url.Link(nameof(GetAuthorAsync),
                new
                {
                    pageNumber = pageList._currentPage - 1,
                    pageSize = pageList._pageSize,
                    birthPlace = parmeters.BirthPlace,
                    serachQuery = parmeters.SerachQuery
                }) : null,
                nextPageLink = pageList.HasNext ? Url.Link(nameof(GetAuthorAsync), new
                {
                    pageNumber = pageList._currentPage + 1,
                    pageSize = pageList._pageSize,
                    birthPlace = parmeters.BirthPlace,
                    serachQuery = parmeters.SerachQuery
                }) : null
            };


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

            var authorDtoList = _mapper.Map<IEnumerable<AuthorDto>>(pageList);
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
