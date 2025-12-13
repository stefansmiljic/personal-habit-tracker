public class Habit
{
    public Guid Id { get; set; }
    public required String Name { get; set; }
    public String? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public GoalType GoalType { get; set; }
}

public enum GoalType
{
    Daily,
    Weekly,
    Monthly,
}
