public class HabitLog
{
    public Guid Id { get; set; }
    public Guid HabitId { get; set; }
    public Habit Habit { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateOnly CompletionDate { get; set; }
}
