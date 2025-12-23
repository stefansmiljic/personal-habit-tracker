public record HabitDto
{
    public Guid Id { get; set; }
    public required String Name { get; set; }
    public String? Description { get; set; }
    public bool IsActive { get; set; }
    public GoalType GoalType { get; set; }
    public DateTime CreatedAt { get; set; }
}
