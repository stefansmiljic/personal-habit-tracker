public interface IHabitRepository
{
    Task<List<Habit>> GetAllHabits();
    Task<Habit?> GetHabitById(Guid id);
    Task AddHabit(Habit habit);
    Task UpdateHabit(Habit habit);
    Task DeleteHabit(Guid id);
}
