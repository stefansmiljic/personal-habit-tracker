public class HabitLogDto
{
    public Guid Id { get; set; }
    public Guid HabitId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateOnly CompletionDate { get; set; }
}
