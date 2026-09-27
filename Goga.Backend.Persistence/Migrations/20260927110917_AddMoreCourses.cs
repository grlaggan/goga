using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Goga.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Информатика" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Основы программирования" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Алгоритмы и структуры данных" }
                });

            migrationBuilder.InsertData(
                table: "sections",
                columns: new[] { "Id", "CourseId", "Name", "PdfPath" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000003"), new Guid("10000000-0000-0000-0000-000000000002"), "Информация и данные", "/pdf/courses/informatics/data.pdf" },
                    { new Guid("20000000-0000-0000-0000-000000000004"), new Guid("10000000-0000-0000-0000-000000000002"), "Компьютерные системы", "/pdf/courses/informatics/systems.pdf" },
                    { new Guid("20000000-0000-0000-0000-000000000005"), new Guid("10000000-0000-0000-0000-000000000003"), "Переменные и типы данных", "/pdf/courses/programming/types.pdf" },
                    { new Guid("20000000-0000-0000-0000-000000000006"), new Guid("10000000-0000-0000-0000-000000000003"), "Функции и классы", "/pdf/courses/programming/functions.pdf" },
                    { new Guid("20000000-0000-0000-0000-000000000007"), new Guid("10000000-0000-0000-0000-000000000004"), "Сложность алгоритмов", "/pdf/courses/algorithms/complexity.pdf" },
                    { new Guid("20000000-0000-0000-0000-000000000008"), new Guid("10000000-0000-0000-0000-000000000004"), "Графы и деревья", "/pdf/courses/algorithms/graphs.pdf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sections",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "sections",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "sections",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "sections",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "sections",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "sections",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));
        }
    }
}
