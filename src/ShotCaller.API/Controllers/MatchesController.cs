using Microsoft.AspNetCore.Mvc;
using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;

namespace ShotCaller.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchesController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchesController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchDto>>> GetAll()
    {
        var matches = await _matchService.GetAllMatchesAsync();
        return Ok(matches);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MatchDto>> GetById(int id)
    {
        var match = await _matchService.GetMatchByIdAsync(id);
        if (match == null) return NotFound();
        return Ok(match);
    }

    [HttpPost]
    public async Task<ActionResult<MatchDto>> Create(CreateMatchDto dto)
    {
        var created = await _matchService.CreateMatchAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}/result")]
    public async Task<ActionResult<MatchDto>> UpdateResult(int id, UpdateMatchResultDto dto)
    {
        var updated = await _matchService.UpdateMatchResultAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _matchService.DeleteMatchAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}