public interface IHabitLogService
{
    Task<List<HabitLogDto>> GetLogsByHabitId(Guid habitId);
    Task<HabitLogDto?> GetLogById(Guid id);
    Task<HabitLogDto> AddLog(CreateHabitLogDto dto);
}
