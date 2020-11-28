using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryExample.api.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthData", "BirthPlace", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1960, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), "北京", "yangwanqing@outlook.com", "杨万青" },
                    { 2, new DateTimeOffset(new DateTime(2005, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), "南京", "ltm@outlook.com", "梁垌明" },
                    { 3, new DateTimeOffset(new DateTime(1993, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), "上海", "dshjdsh@163.com", "刘铁萌" },
                    { 4, new DateTimeOffset(new DateTime(1995, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), "深圳", "zzh@outlook.com", "赵梓恒" },
                    { 5, new DateTimeOffset(new DateTime(1994, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), "成都", "34782742@outlook.com", "鲁小冲" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Page", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Description of Book 1", 786, "Book1" },
                    { 4, 2, "Description of Book 4", 786, "Book4" },
                    { 6, 2, "Description of Book 6", 786, "Book6" },
                    { 2, 3, "Description of Book 2", 786, "Book2" },
                    { 3, 4, "Description of Book 3", 786, "Book3" },
                    { 5, 5, "Description of Book 5", 786, "Book5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
