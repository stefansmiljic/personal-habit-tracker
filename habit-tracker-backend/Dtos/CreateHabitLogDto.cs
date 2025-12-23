using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public record CreateHabitLogDto
{
    public Guid HabitId { get; set; }
    public DateOnly CompletionDate { get; set; }
}
