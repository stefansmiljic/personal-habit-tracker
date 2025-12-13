public static class HabitMapper
{
    public static Habit ToEntity(CreateHabitDto dto)
    {
        return new Habit
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            GoalType = dto.GoalType,
            CreatedAt = DateTime.Now,
            IsActive = true,
        };
    }

    public static void ApplyUpdates(Habit habit, UpdateHabitDto dto)
    {
        if (!string.IsNullOrEmpty(dto.Name))
            habit.Name = dto.Name;
        if (dto.Description != null)
            habit.Description = dto.Description;
        if (dto.IsActive != null)
            habit.IsActive = dto.IsActive.Value;
        if (dto.GoalType != null)
            habit.GoalType = dto.GoalType.Value;
    }

    public static HabitDto ToDto(Habit habit)
    {
        return new HabitDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            IsActive = habit.IsActive,
            GoalType = habit.GoalType,
            CreatedAt = habit.CreatedAt,
        };
    }

    public static List<HabitDto> ToDtoList(IEnumerable<Habit> habits) =>
        habits.Select(ToDto).ToList();
}
