using Microsoft.EntityFrameworkCore;

public class HabitLogRepository : IHabitLogRepository
{
    private readonly AppDbContext _context;

    public HabitLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddLog(HabitLog log)
    {
        _context.HabitLogs.Add(log);
        await _context.SaveChangesAsync();
    }

    public async Task<HabitLog?> GetLogById(Guid id) => await _context.HabitLogs.FindAsync(id);

    public async Task<List<HabitLog>> GetLogsByHabitId(Guid habitId) =>
        await _context.HabitLogs.Where(log => log.HabitId == habitId).ToListAsync();
}
