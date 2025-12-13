public static class HabitLogMapper
{
    public static HabitLog ToEntity(CreateHabitLogDto dto)
    {
        return new HabitLog
        {
            Id = Guid.NewGuid(),
            HabitId = dto.HabitId,
            CreatedAt = DateTime.Now,
            CompletionDate = dto.CompletionDate,
        };
    }

    public static HabitLogDto ToDto(HabitLog log)
    {
        return new HabitLogDto
        {
            Id = log.Id,
            HabitId = log.HabitId,
            CompletionDate = log.CompletionDate,
            CreatedAt = log.CreatedAt,
        };
    }

    public static List<HabitLogDto> ToDtoList(IEnumerable<HabitLog> logs) =>
        logs.Select(ToDto).ToList();
}
