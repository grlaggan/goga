using Goga.Backend.Domain.Users;
using Goga.Backend.Domain.Courses;
using Goga.Backend.Domain.Timetables;
using Microsoft.EntityFrameworkCore;

namespace Goga.Backend.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<UserCourse> UserCourses => Set<UserCourse>();
    public DbSet<ScheduleEntry> ScheduleEntries => Set<ScheduleEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(user => user.Id);
            entity.Property(user => user.IdentityServerSubject).HasMaxLength(200).IsRequired();
            entity.HasIndex(user => user.IdentityServerSubject).IsUnique();
            entity.Property(user => user.Email).HasMaxLength(320).IsRequired();
            entity.HasIndex(user => user.Email).IsUnique();
            entity.Property(user => user.Group).HasMaxLength(100).IsRequired();
            entity.Property(user => user.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(user => user.LastName).HasMaxLength(100).IsRequired();
            entity.Property(user => user.PasswordHash).HasMaxLength(500).IsRequired();
            entity.Property(user => user.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("courses");
            entity.HasKey(course => course.Id);
            entity.Property(course => course.Name).HasMaxLength(200).IsRequired();
            entity.HasMany(course => course.Sections).WithOne(section => section.Course)
                .HasForeignKey(section => section.CourseId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("sections");
            entity.HasKey(section => section.Id);
            entity.Property(section => section.Name).HasMaxLength(200).IsRequired();
            entity.Property(section => section.PdfPath).HasMaxLength(500).IsRequired();
        });

        modelBuilder.Entity<UserCourse>(entity =>
        {
            entity.ToTable("user_courses");
            entity.HasKey(enrollment => new { enrollment.UserId, enrollment.CourseId });
            entity.Property(enrollment => enrollment.EnrolledAt).IsRequired();
            entity.HasOne(enrollment => enrollment.User).WithMany(user => user.Courses)
                .HasForeignKey(enrollment => enrollment.UserId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(enrollment => enrollment.Course).WithMany(course => course.Enrollments)
                .HasForeignKey(enrollment => enrollment.CourseId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ScheduleEntry>(entity =>
        {
            entity.ToTable("schedule_entries");
            entity.HasKey(entry => entry.Id);
            entity.Property(entry => entry.Group).HasMaxLength(100).IsRequired();
            entity.Property(entry => entry.DayOfWeek).IsRequired();
            entity.Property(entry => entry.WeekParity).IsRequired();
            entity.Property(entry => entry.Subject).HasMaxLength(200).IsRequired();
            entity.Property(entry => entry.Type).IsRequired();
            entity.Property(entry => entry.Format).IsRequired();
            entity.Property(entry => entry.Number).IsRequired();
            entity.Property(entry => entry.Building).HasMaxLength(100).IsRequired();
            entity.Property(entry => entry.Auditorium).HasMaxLength(100).IsRequired();
            entity.Property(entry => entry.Lecturer).HasMaxLength(200).IsRequired();
            entity.HasIndex(entry => new { entry.Group, entry.DayOfWeek, entry.WeekParity });
        });

        var scheduleEntries = new List<ScheduleEntry>();
        var groups = new[] { "ИС-101", "БПИ-101" };
        var subjects = new[] { "Информатика", "Математический анализ", "Программирование", "Базы данных", "Алгоритмы", "Архитектура ПО", "Проектная работа" };
        var entryNumber = 1;
        foreach (var group in groups)
        foreach (var day in Enum.GetValues<DayOfWeek>())
        foreach (var parity in Enum.GetValues<WeekParity>())
        {
            scheduleEntries.Add(new ScheduleEntry(
                new Guid($"30000000-0000-0000-0000-{entryNumber:D12}"),
                group, day, parity, subjects[(int)day],
                day is DayOfWeek.Tuesday or DayOfWeek.Thursday ? LessonType.Practice : LessonType.Lecture,
                day is DayOfWeek.Friday ? LessonFormat.Asynchronous : LessonFormat.Synchronous,
                (int)day % 3 + 1,
                group == "ИС-101" ? "Корпус 1" : "Корпус 2",
                $"ауд. {101 + (int)day}",
                group == "ИС-101" ? "Иванов И.И." : "Петров П.П."));
            entryNumber++;
        }
        modelBuilder.Entity<ScheduleEntry>().HasData(scheduleEntries);

        var courseId = new Guid("10000000-0000-0000-0000-000000000001");
        var informaticsId = new Guid("10000000-0000-0000-0000-000000000002");
        var programmingId = new Guid("10000000-0000-0000-0000-000000000003");
        var algorithmsId = new Guid("10000000-0000-0000-0000-000000000004");
        modelBuilder.Entity<Course>().HasData(
            new { Id = courseId, Name = "Основы backend-разработки" },
            new { Id = informaticsId, Name = "Информатика" },
            new { Id = programmingId, Name = "Основы программирования" },
            new { Id = algorithmsId, Name = "Алгоритмы и структуры данных" });
        modelBuilder.Entity<Section>().HasData(
            new { Id = new Guid("20000000-0000-0000-0000-000000000001"), CourseId = courseId, Name = "Введение", PdfPath = "/pdf/courses/backend/introduction.pdf" },
            new { Id = new Guid("20000000-0000-0000-0000-000000000002"), CourseId = courseId, Name = "Архитектура приложения", PdfPath = "/pdf/courses/backend/architecture.pdf" },
            new { Id = new Guid("20000000-0000-0000-0000-000000000003"), CourseId = informaticsId, Name = "Информация и данные", PdfPath = "/pdf/courses/informatics/data.pdf" },
            new { Id = new Guid("20000000-0000-0000-0000-000000000004"), CourseId = informaticsId, Name = "Компьютерные системы", PdfPath = "/pdf/courses/informatics/systems.pdf" },
            new { Id = new Guid("20000000-0000-0000-0000-000000000005"), CourseId = programmingId, Name = "Переменные и типы данных", PdfPath = "/pdf/courses/programming/types.pdf" },
            new { Id = new Guid("20000000-0000-0000-0000-000000000006"), CourseId = programmingId, Name = "Функции и классы", PdfPath = "/pdf/courses/programming/functions.pdf" },
            new { Id = new Guid("20000000-0000-0000-0000-000000000007"), CourseId = algorithmsId, Name = "Сложность алгоритмов", PdfPath = "/pdf/courses/algorithms/complexity.pdf" },
            new { Id = new Guid("20000000-0000-0000-0000-000000000008"), CourseId = algorithmsId, Name = "Графы и деревья", PdfPath = "/pdf/courses/algorithms/graphs.pdf" });
    }
}
