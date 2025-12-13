using Microsoft.IdentityModel.Tokens;

public class HabitService : IHabitService
{
    private IHabitRepository _habitRepository;

    public HabitService(IHabitRepository habitRepository)
    {
        _habitRepository = habitRepository;
    }

    public async Task<HabitDto> AddHabit(CreateHabitDto dto)
    {
        if (string.IsNullOrEmpty(dto.Name))
            throw new Exception();

        var habit = new Habit()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            GoalType = dto.GoalType,
            CreatedAt = DateTime.Now,
            IsActive = true,
        };

        var habitDto = new HabitDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            IsActive = habit.IsActive,
            GoalType = habit.GoalType,
            CreatedAt = habit.CreatedAt,
        };

        await _habitRepository.AddHabit(habit);
        return habitDto;
    }

    public async Task DeleteHabit(Guid id) => await _habitRepository.DeleteHabit(id);

    public async Task<List<HabitDto>> GetAllHabits()
    {
        var habits = await _habitRepository.GetAllHabits();
        return habits
            .Select(habit => new HabitDto
            {
                Id = habit.Id,
                Name = habit.Name,
                Description = habit.Description,
                IsActive = habit.IsActive,
                GoalType = habit.GoalType,
                CreatedAt = habit.CreatedAt,
            })
            .ToList();
    }

    public async Task<HabitDto?> GetHabitById(Guid id)
    {
        var habit = await _habitRepository.GetHabitById(id) ?? throw new Exception();
        var habitDto = new HabitDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            IsActive = habit.IsActive,
            GoalType = habit.GoalType,
            CreatedAt = habit.CreatedAt,
        };
        return habitDto;
    }

    public async Task<HabitDto?> UpdateHabit(Guid id, UpdateHabitDto dto)
    {
        var habit = await _habitRepository.GetHabitById(id) ?? throw new Exception();
        if (!string.IsNullOrEmpty(dto.Name))
            habit.Name = dto.Name;
        if (dto.Description != null)
            habit.Description = dto.Description;
        if (dto.IsActive != null)
            habit.IsActive = dto.IsActive.Value;
        if (dto.GoalType != null)
            habit.GoalType = dto.GoalType.Value;

        await _habitRepository.UpdateHabit(habit);

        var habitDto = new HabitDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            IsActive = habit.IsActive,
            GoalType = habit.GoalType,
            CreatedAt = habit.CreatedAt,
        };
        return habitDto;
    }
}
