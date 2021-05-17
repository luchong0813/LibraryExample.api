using LibraryExample.api.Entities;
using LibraryExample.api.Helpers;
using Microsoft.EntityFrameworkCore;
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
            //var queryableAuthors = _dbContext.Set<Author>();

            //return PageList<Author>.CreateAsync(queryableAuthors, parmeters.PageNumber, parmeters.PageSize);

            IQueryable<Author> queryableAuthors = _dbContext.Set<Author>();
            //如果过滤条件不为空且不含空白或空格
            if (!string.IsNullOrWhiteSpace(parmeters.BirthPlace))
            {
                queryableAuthors = queryableAuthors.Where(m => m.BirthPlace.ToLower() == parmeters.BirthPlace);
            }
            if (!string.IsNullOrWhiteSpace(parmeters.SerachQuery))
            {
                queryableAuthors = queryableAuthors
                    .Where(m => m.BirthPlace.ToLower().Contains(parmeters.SerachQuery.ToLower())
                    || m.Name.ToLower().Contains(parmeters.SerachQuery.ToLower()));
            }
            //if (parmeters.StoryBy == "Name")
            //{
            //    queryableAuthors=queryableAuthors.OrderBy()
            //}
            //var orderedAuthors = queryableAuthors.OrderBy(parmeters.StoryBy);
            //var totalCount = queryableAuthors.Count();
            //var items = queryableAuthors
            //    .Skip((parmeters.PageNumber - 1) * parmeters.PageSize)
            //    .Take(parmeters.PageSize).ToList();

            return PageList<Author>.CreateAsync(queryableAuthors, parmeters.PageNumber, parmeters.PageSize);
        }
    }
}
