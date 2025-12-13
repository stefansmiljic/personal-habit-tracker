public class HabitLogService : IHabitLogService
{
    private readonly IHabitLogRepository _logRepository;

    public HabitLogService(IHabitLogRepository logRepo)
    {
        _logRepository = logRepo;
    }

    public async Task<HabitLogDto> AddLog(CreateHabitLogDto dto)
    {
        var log = HabitLogMapper.ToEntity(dto);
        await _logRepository.AddLog(log);
        return HabitLogMapper.ToDto(log);
    }

    public async Task<HabitLogDto?> GetLogById(Guid id)
    {
        var log = await _logRepository.GetLogById(id);
        if (log == null)
            return null;
        return HabitLogMapper.ToDto(log);
    }

    public async Task<List<HabitLogDto>> GetLogsByHabitId(Guid habitId)
    {
        var logs = await _logRepository.GetLogsByHabitId(habitId);
        return HabitLogMapper.ToDtoList(logs);
    }
}
