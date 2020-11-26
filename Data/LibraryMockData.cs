using LibraryExample.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Data
{
    public class LibraryMockData
    {
        public static LibraryMockData Current { get; } = new LibraryMockData();

        public List<AuthorDto> Authors { get; private set; }
        public List<BookDto> Books { get; private set; }

        public LibraryMockData()
        {
            Authors = new List<AuthorDto>
            {
                new AuthorDto{Id=1,Name="杨万青",Age=28,Email="yangwanqing@outlook.com"},
                new AuthorDto{Id=2,Name="梁垌明",Age=28,Email="ltm@outlook.com"},
                new AuthorDto{Id=3,Name="刘铁萌",Age=28,Email="dshjdsh@163.com"},
                new AuthorDto{Id=4,Name="赵梓恒",Age=28,Email="zzh@outlook.com"},
                new AuthorDto{Id=5,Name="鲁小冲",Age=28,Email="34782742@outlook.com"},
            };
            Books = new List<BookDto>
            {
                new BookDto{Id=1,Title="Book1",Description="Description of Book 1",Pages=786,AuthorId=1},
                new BookDto{Id=2,Title="Book2",Description="Description of Book 2",Pages=786,AuthorId=3},
                new BookDto{Id=3,Title="Book3",Description="Description of Book 3",Pages=786,AuthorId=4},
                new BookDto{Id=4,Title="Book4",Description="Description of Book 4",Pages=786,AuthorId=2},
                new BookDto{Id=5,Title="Book5",Description="Description of Book 5",Pages=786,AuthorId=5},
                new BookDto{Id=6,Title="Book6",Description="Description of Book 6",Pages=786,AuthorId=2},
            };
        }


    }
}
