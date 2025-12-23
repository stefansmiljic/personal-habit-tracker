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
            throw new Exception("Name is empty");
        var habit = HabitMapper.ToEntity(dto);

        await _habitRepository.AddHabit(habit);
        return HabitMapper.ToDto(habit);
    }

    public async Task DeleteHabit(Guid id) => await _habitRepository.DeleteHabit(id);

    public async Task<List<HabitDto>> GetAllHabits()
    {
        var habits = await _habitRepository.GetAllHabits();
        return HabitMapper.ToDtoList(habits);
    }

    public async Task<HabitDto?> GetHabitById(Guid id)
    {
        var habit = await _habitRepository.GetHabitById(id) ?? throw new Exception();
        return HabitMapper.ToDto(habit);
    }

    public async Task<HabitDto?> UpdateHabit(Guid id, UpdateHabitDto dto)
    {
        var habit = await _habitRepository.GetHabitById(id) ?? throw new Exception();
        HabitMapper.ApplyUpdates(habit, dto);
        await _habitRepository.UpdateHabit(habit);
        return HabitMapper.ToDto(habit);
    }
}
