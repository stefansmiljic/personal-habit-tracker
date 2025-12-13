using Microsoft.EntityFrameworkCore;

public class HabitRepository : IHabitRepository
{
    private readonly AppDbContext _context;

    public HabitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddHabit(Habit habit)
    {
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHabit(Guid id)
    {
        var habit = await _context.Habits.FindAsync(id);
        if (habit != null)
        {
            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Habit>> GetAllHabits() => await _context.Habits.ToListAsync();

    public async Task<Habit?> GetHabitById(Guid id) => await _context.Habits.FindAsync(id);

    public async Task UpdateHabit(Habit habit)
    {
        _context.Habits.Update(habit);
        await _context.SaveChangesAsync();
    }
}
