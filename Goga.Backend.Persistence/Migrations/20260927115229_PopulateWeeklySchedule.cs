using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Goga.Backend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PopulateWeeklySchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                columns: new[] { "DayOfWeek", "Subject" },
                values: new object[] { 0, "Информатика" });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                columns: new[] { "Auditorium", "Building", "DayOfWeek", "Lecturer", "Number", "Subject", "Type", "WeekParity" },
                values: new object[] { "ауд. 101", "Корпус 1", 0, "Иванов И.И.", 1, "Информатика", 0, 1 });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                columns: new[] { "Auditorium", "DayOfWeek", "Lecturer", "Number", "Subject", "WeekParity" },
                values: new object[] { "ауд. 102", 1, "Иванов И.И.", 2, "Математический анализ", 0 });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                columns: new[] { "Auditorium", "Building", "Group", "Lecturer", "Number", "Subject", "WeekParity" },
                values: new object[] { "ауд. 102", "Корпус 1", "ИС-101", "Иванов И.И.", 2, "Математический анализ", 1 });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                columns: new[] { "Auditorium", "Building", "DayOfWeek", "Format", "Group", "Lecturer", "Number", "Subject", "WeekParity" },
                values: new object[] { "ауд. 103", "Корпус 1", 2, 0, "ИС-101", "Иванов И.И.", 3, "Программирование", 0 });

            migrationBuilder.InsertData(
                table: "schedule_entries",
                columns: new[] { "Id", "Auditorium", "Building", "DayOfWeek", "Format", "Group", "Lecturer", "Number", "Subject", "Type", "WeekParity" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000006"), "ауд. 103", "Корпус 1", 2, 0, "ИС-101", "Иванов И.И.", 3, "Программирование", 1, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000007"), "ауд. 104", "Корпус 1", 3, 0, "ИС-101", "Иванов И.И.", 1, "Базы данных", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000008"), "ауд. 104", "Корпус 1", 3, 0, "ИС-101", "Иванов И.И.", 1, "Базы данных", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000009"), "ауд. 105", "Корпус 1", 4, 0, "ИС-101", "Иванов И.И.", 2, "Алгоритмы", 1, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000010"), "ауд. 105", "Корпус 1", 4, 0, "ИС-101", "Иванов И.И.", 2, "Алгоритмы", 1, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000011"), "ауд. 106", "Корпус 1", 5, 1, "ИС-101", "Иванов И.И.", 3, "Архитектура ПО", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000012"), "ауд. 106", "Корпус 1", 5, 1, "ИС-101", "Иванов И.И.", 3, "Архитектура ПО", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000013"), "ауд. 107", "Корпус 1", 6, 0, "ИС-101", "Иванов И.И.", 1, "Проектная работа", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000014"), "ауд. 107", "Корпус 1", 6, 0, "ИС-101", "Иванов И.И.", 1, "Проектная работа", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000015"), "ауд. 101", "Корпус 2", 0, 0, "БПИ-101", "Петров П.П.", 1, "Информатика", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000016"), "ауд. 101", "Корпус 2", 0, 0, "БПИ-101", "Петров П.П.", 1, "Информатика", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000017"), "ауд. 102", "Корпус 2", 1, 0, "БПИ-101", "Петров П.П.", 2, "Математический анализ", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000018"), "ауд. 102", "Корпус 2", 1, 0, "БПИ-101", "Петров П.П.", 2, "Математический анализ", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000019"), "ауд. 103", "Корпус 2", 2, 0, "БПИ-101", "Петров П.П.", 3, "Программирование", 1, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000020"), "ауд. 103", "Корпус 2", 2, 0, "БПИ-101", "Петров П.П.", 3, "Программирование", 1, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000021"), "ауд. 104", "Корпус 2", 3, 0, "БПИ-101", "Петров П.П.", 1, "Базы данных", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000022"), "ауд. 104", "Корпус 2", 3, 0, "БПИ-101", "Петров П.П.", 1, "Базы данных", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000023"), "ауд. 105", "Корпус 2", 4, 0, "БПИ-101", "Петров П.П.", 2, "Алгоритмы", 1, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000024"), "ауд. 105", "Корпус 2", 4, 0, "БПИ-101", "Петров П.П.", 2, "Алгоритмы", 1, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000025"), "ауд. 106", "Корпус 2", 5, 1, "БПИ-101", "Петров П.П.", 3, "Архитектура ПО", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000026"), "ауд. 106", "Корпус 2", 5, 1, "БПИ-101", "Петров П.П.", 3, "Архитектура ПО", 0, 1 },
                    { new Guid("30000000-0000-0000-0000-000000000027"), "ауд. 107", "Корпус 2", 6, 0, "БПИ-101", "Петров П.П.", 1, "Проектная работа", 0, 0 },
                    { new Guid("30000000-0000-0000-0000-000000000028"), "ауд. 107", "Корпус 2", 6, 0, "БПИ-101", "Петров П.П.", 1, "Проектная работа", 0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000028"));

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                columns: new[] { "DayOfWeek", "Subject" },
                values: new object[] { 1, "Математический анализ" });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                columns: new[] { "Auditorium", "Building", "DayOfWeek", "Lecturer", "Number", "Subject", "Type", "WeekParity" },
                values: new object[] { "ауд. 310", "Корпус 3", 1, "Сидоров С.С.", 2, "Программирование", 1, 0 });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                columns: new[] { "Auditorium", "DayOfWeek", "Lecturer", "Number", "Subject", "WeekParity" },
                values: new object[] { "ауд. 112", 2, "Козлов К.К.", 3, "Базы данных", 1 });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                columns: new[] { "Auditorium", "Building", "Group", "Lecturer", "Number", "Subject", "WeekParity" },
                values: new object[] { "ауд. 205", "Корпус 2", "БПИ-101", "Петров П.П.", 1, "Информатика", 0 });

            migrationBuilder.UpdateData(
                table: "schedule_entries",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                columns: new[] { "Auditorium", "Building", "DayOfWeek", "Format", "Group", "Lecturer", "Number", "Subject", "WeekParity" },
                values: new object[] { "ауд. 305", "Корпус 3", 3, 1, "БПИ-101", "Смирнов А.А.", 2, "Алгоритмы", 1 });
        }
    }
}
