using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HabitController : ControllerBase
{
    private readonly IHabitService _habitService;

    public HabitController(IHabitService habitService)
    {
        _habitService = habitService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType<HabitDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HabitDto>> GetHabitById(Guid id)
    {
        var habit = await _habitService.GetHabitById(id);
        return habit is null ? NotFound() : Ok(habit);
    }

    [HttpGet]
    [ProducesResponseType<List<HabitDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<HabitDto>>> GetAllHabits()
    {
        var habits = await _habitService.GetAllHabits();
        return Ok(habits);
    }

    [HttpPost]
    [ProducesResponseType(typeof(HabitDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HabitDto>> AddHabit([FromBody] CreateHabitDto dto)
    {
        var created = await _habitService.AddHabit(dto);
        return CreatedAtAction(nameof(GetHabitById), new { id = created.Id }, created);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(HabitDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HabitDto?>> UpdateHabit(Guid id, [FromBody] UpdateHabitDto dto)
    {
        var result = await _habitService.UpdateHabit(id, dto);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHabit(Guid id)
    {
        await _habitService.DeleteHabit(id);
        return NoContent();
    }
}
