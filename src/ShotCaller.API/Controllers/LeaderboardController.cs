using Microsoft.AspNetCore.Mvc;
using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;

namespace ShotCaller.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly ILeaderboardService _leaderboardService;

    public LeaderboardController(ILeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaderboardEntryDto>>> GetLeaderboard()
    {
        var leaderboard = await _leaderboardService.GetLeaderboardAsync();
        return Ok(leaderboard);
    }
}