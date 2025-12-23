using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HabitLogController : ControllerBase
{
    private readonly IHabitLogService _habitLogService;

    public HabitLogController(IHabitLogService habitLogService)
    {
        _habitLogService = habitLogService;
    }

    [HttpGet("by-habit/{habitId}")]
    [ProducesResponseType<List<HabitLogDto>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<HabitLogDto>>> GetLogsByHabitId(Guid habitId)
    {
        var logs = await _habitLogService.GetLogsByHabitId(habitId);
        return Ok(logs);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<HabitLogDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HabitLogDto?>> GetLogById(Guid id)
    {
        var log = await _habitLogService.GetLogById(id);
        return log is null ? NotFound() : Ok(log);
    }

    [HttpPost]
    [ProducesResponseType(typeof(HabitLogDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HabitLogDto>> AddLog([FromBody] CreateHabitLogDto dto)
    {
        var created = await _habitLogService.AddLog(dto);
        return CreatedAtAction(nameof(GetLogById), new { id = created.Id }, created);
    }
}
