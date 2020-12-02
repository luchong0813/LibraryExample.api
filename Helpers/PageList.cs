using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Helpers
{
    public class PageList<T> : List<T>
    {
        public PageList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            _totalCount = totalCount;
            _pageNumber = pageNumber;
            _pageSize = pageSize;

            TotalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            AddRange(items);
        }

        public int _totalCount { get; }
        public int _pageNumber { get; }
        public int _pageSize { get; }

        public int TotalPage { get; }

        public bool HasPrevious => _pageNumber > 1;
        public bool HasNext => _pageNumber < TotalPage;


        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var list = new PageList<T>(items, totalCount, pageNumber, pageSize);
            return await Task.FromResult(list);
        }
    }
}
