public interface IHabitLogRepository
{
    Task<List<HabitLog>> GetLogsByHabitId(Guid habitId);
    Task<HabitLog?> GetLogById(Guid id);
    Task AddLog(HabitLog log);
}
