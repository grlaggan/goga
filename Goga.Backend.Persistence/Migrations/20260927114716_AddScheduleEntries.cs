using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Goga.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduleEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "schedule_entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Group = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    WeekParity = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Building = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Auditorium = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lecturer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule_entries", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "schedule_entries",
                columns: new[] { "Id", "Auditorium", "Building", "DayOfWeek", "Format", "Group", "Lecturer", "Number", "Subject", "Type", "WeekParity" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), "ауд. 101", "Корпус 1", 1, 0, "ИС-101", "Иванов И.И.", 1, "Математический анализ", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "ауд. 310", "Корпус 3", 1, 0, "ИС-101", "Сидоров С.С.", 2, "Программирование", 1, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "ауд. 112", "Корпус 1", 2, 0, "ИС-101", "Козлов К.К.", 3, "Базы данных", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "ауд. 205", "Корпус 2", 1, 0, "БПИ-101", "Петров П.П.", 1, "Информатика", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000005"), "ауд. 305", "Корпус 3", 3, 1, "БПИ-101", "Смирнов А.А.", 2, "Алгоритмы", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_schedule_entries_Group_DayOfWeek_WeekParity",
                table: "schedule_entries",
                columns: new[] { "Group", "DayOfWeek", "WeekParity" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schedule_entries");
        }
    }
}
