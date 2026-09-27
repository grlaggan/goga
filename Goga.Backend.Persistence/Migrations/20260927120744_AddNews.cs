using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Goga.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "news",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), "В приложении доступны курсы, лекции и расписание занятий.", "Добро пожаловать в Goga" },
                    { new Guid("40000000-0000-0000-0000-000000000002"), "Изучайте информатику, программирование, алгоритмы и backend-разработку.", "Добавлены новые курсы" },
                    { new Guid("40000000-0000-0000-0000-000000000003"), "Актуальное расписание доступно в разделе «Расписание».", "Проверьте расписание" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news");
        }
    }
}
