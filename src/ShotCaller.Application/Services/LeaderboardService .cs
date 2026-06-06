using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;

namespace ShotCaller.Application.Services;

public class LeaderboardService : ILeaderboardService
{
    private readonly IPredictionRepository _predictionRepository;

    public LeaderboardService(IPredictionRepository predictionRepository)
    {
        _predictionRepository = predictionRepository;
    }

    public async Task<IEnumerable<LeaderboardEntryDto>> GetLeaderboardAsync()
    {
        var predictions = await _predictionRepository.GetAllAsync();

        return predictions
            .GroupBy(p => p.UserName)
            .Select(g => new LeaderboardEntryDto
            {
                UserName = g.Key,
                TotalPoints = g.Sum(p => p.Points ?? 0),
                PredictionCount = g.Count()
            })
            .OrderByDescending(e => e.TotalPoints)
            .ToList();
    }
}