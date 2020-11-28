using LibraryExample.api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
            new Author
            {
                Id = 1,
                Name = "杨万青",
                BirthData = new DateTimeOffset(new DateTime(1960, 11, 18)),
                BirthPlace = "北京",
                Email = "yangwanqing@outlook.com"
            },
            new Author
            {
                Id = 2,
                Name = "梁垌明",
                BirthData = new DateTimeOffset(new DateTime(2005, 05, 23)),
                BirthPlace = "南京",
                Email = "ltm@outlook.com"
            },
            new Author
            {
                Id = 3,
                Name = "刘铁萌",
                BirthData = new DateTimeOffset(new DateTime(1993, 12, 25)),
                BirthPlace = "上海",
                Email = "dshjdsh@163.com"
            },
            new Author
            {
                Id = 4,
                Name = "赵梓恒",
                BirthData = new DateTimeOffset(new DateTime(1995, 06, 03)),
                BirthPlace = "深圳",
                Email = "zzh@outlook.com"
            },
            new Author
            {
                Id = 5,
                Name = "鲁小冲",
                BirthData = new DateTimeOffset(new DateTime(1994, 12, 24)),
                BirthPlace = "成都",
                Email = "34782742@outlook.com"
            });

            modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Book1",
                Description = "Description of Book 1",
                Page = 786,
                AuthorId = 1
            },
            new Book
            {
                Id = 2,
                Title = "Book2",
                Description = "Description of Book 2",
                Page = 786,
                AuthorId = 3
            },
            new Book
            {
                Id = 3,
                Title = "Book3",
                Description = "Description of Book 3",
                Page = 786,
                AuthorId = 4
            },
            new Book
            {
                Id = 4,
                Title = "Book4",
                Description = "Description of Book 4",
                Page = 786,
                AuthorId = 2
            },
            new Book
            {
                Id = 5,
                Title = "Book5",
                Description = "Description of Book 5",
                Page = 786,
                AuthorId = 5
            },
            new Book
            {
                Id = 6,
                Title = "Book6",
                Description = "Description of Book 6",
                Page = 786,
                AuthorId = 2
            });
        }
    }
}
