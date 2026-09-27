using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Sports;

namespace Goga.Backend.Application.Sports;

public sealed class SportSectionService(ISportSectionRepository sportSectionRepository) : ISportSectionService
{
    private static readonly IReadOnlyList<SportSection> Sections = new List<SportSection>
    {
        new("Адаптивная физическая культура", "Занятия для людей с ограниченными возможностями здоровья", "1 корпус"),
        new("Атлетическая гимнастика", "Силовые упражнения с собственным весом и отягощениями", "1 корпус"),
        new("Баскетбол", "Командная игра с мячом 5×5", "1 корпус"),
        new("Бокс", "Единоборство с использованием ударной техники", "1 корпус"),
        new("Волейбол", "Командная игра с мячом через сетку", "1 корпус"),
        new("Гиревой спорт", "Поднятие гирь в соревновательном формате", "1 корпус"),
        new("Гольф", "Игра с мячом и клюшками на открытой площадке", "1 корпус"),
        new("Комплексная специализация", "Разносторонняя физическая подготовка", "1 корпус"),
        new("Легкая атлетика", "Бег, прыжки, метания и спортивная ходьба", "1 корпус"),
        new("Настольный теннис", "Игра с мячом и ракетками на столе", "1 корпус"),
        new("Оздоровительная физическая культура", "Общая физическая подготовка и здоровый образ жизни", "1 корпус"),
        new("Плавание", "Занятия в бассейне разными стилями", "1 корпус"),
        new("Подвижные игры", "Активные игры для развития координации и командного духа", "1 корпус"),
        new("Регби", "Командная контактная игра с овальным мячом", "1 корпус"),
        new("Скалолазание", "Подъём по искусственным скалодромам", "1 корпус"),
        new("Скалолазание", "Подъём по естественному рельефу", "1 корпус"),
        new("Спортивная борьба", "Единоборство с использованием бросков и удержаний", "1 корпус"),
        new("Спортивный туризм", "Походы, ориентирование и выживание в природе", "1 корпус"),
        new("Фитнес-аэробика", "Ритмичные упражнения под музыку", "1 корпус"),
        new("Футбол", "Командная игра с мячом 11×11", "1 корпус")
    };

    public Task<IReadOnlyList<SportSection>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Sections);
    }

    public Task<string?> GetUserEnrollmentAsync(string userEmail, CancellationToken cancellationToken)
    {
        return sportSectionRepository.GetUserEnrollmentAsync(userEmail, cancellationToken);
    }

    public Task<bool> EnrollAsync(string sectionName, string userEmail, CancellationToken cancellationToken)
    {
        return sportSectionRepository.EnrollAsync(sectionName, userEmail, cancellationToken);
    }
}
