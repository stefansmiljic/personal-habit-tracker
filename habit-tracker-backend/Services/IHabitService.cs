public interface IHabitService
{
    Task<List<HabitDto>> GetAllHabits();
    Task<HabitDto?> GetHabitById(Guid id);
    Task<HabitDto> AddHabit(CreateHabitDto dto);
    Task<HabitDto?> UpdateHabit(Guid id, UpdateHabitDto dto);
    Task DeleteHabit(Guid id);
}
