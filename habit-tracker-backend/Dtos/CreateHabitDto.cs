public record CreateHabitDto
{
    public required String Name { get; set; }
    public String? Description { get; set; }
    public GoalType GoalType { get; set; }
}
