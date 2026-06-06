using Microsoft.AspNetCore.Mvc;
using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;

namespace ShotCaller.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PredictionsController : ControllerBase
{
    private readonly IPredictionService _predictionService;

    public PredictionsController(IPredictionService predictionService)
    {
        _predictionService = predictionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PredictionDto>>> GetAll()
    {
        var predictions = await _predictionService.GetAllPredictionsAsync();
        return Ok(predictions);
    }

    [HttpGet("match/{matchId}")]
    public async Task<ActionResult<IEnumerable<PredictionDto>>> GetByMatch(int matchId)
    {
        var predictions = await _predictionService.GetPredictionsByMatchIdAsync(matchId);
        return Ok(predictions);
    }

    [HttpGet("user/{userName}")]
    public async Task<ActionResult<IEnumerable<PredictionDto>>> GetByUser(string userName)
    {
        var predictions = await _predictionService.GetPredictionsByUserAsync(userName);
        return Ok(predictions);
    }

    [HttpPost]
    public async Task<ActionResult<PredictionDto>> Create(CreatePredictionDto dto)
    {
        var created = await _predictionService.CreatePredictionAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PredictionDto>> Update(int id, UpdatePredictionDto dto)
    {
        var updated = await _predictionService.UpdatePredictionAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _predictionService.DeletePredictionAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}