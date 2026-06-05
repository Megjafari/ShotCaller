using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;
using ShotCaller.Domain;

namespace ShotCaller.Application.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _matchRepository;
    private readonly IPredictionRepository _predictionRepository;

    public MatchService(IMatchRepository matchRepository, IPredictionRepository predictionRepository)
    {
        _matchRepository = matchRepository;
        _predictionRepository = predictionRepository;
    }

    public async Task<IEnumerable<MatchDto>> GetAllMatchesAsync()
    {
        var matches = await _matchRepository.GetAllAsync();
        return matches.Select(MapToDto);
    }

    public async Task<MatchDto?> GetMatchByIdAsync(int id)
    {
        var match = await _matchRepository.GetByIdAsync(id);
        return match is null ? null : MapToDto(match);
    }

    public async Task<MatchDto> CreateMatchAsync(CreateMatchDto dto)
    {
        var match = new Match
        {
            HomeTeam = dto.HomeTeam,
            AwayTeam = dto.AwayTeam,
            KickoffUtc = dto.KickoffUtc,
            Group = dto.Group
        };

        await _matchRepository.AddAsync(match);
        await _matchRepository.SaveChangesAsync();

        return MapToDto(match);
    }

    public async Task<MatchDto?> UpdateMatchResultAsync(int id, UpdateMatchResultDto dto)
    {
        var match = await _matchRepository.GetByIdAsync(id);
        if (match is null)
            return null;

        match.HomeScore = dto.HomeScore;
        match.AwayScore = dto.AwayScore;
        _matchRepository.Update(match);

        // Poängsätt alla predictions på matchen
        var predictions = await _predictionRepository.GetByMatchIdAsync(id);
        foreach (var prediction in predictions)
        {
            prediction.Points = PointsCalculator.Calculate(
                prediction.PredictedHomeScore,
                prediction.PredictedAwayScore,
                dto.HomeScore,
                dto.AwayScore);
            _predictionRepository.Update(prediction);
        }

        await _matchRepository.SaveChangesAsync();

        return MapToDto(match);
    }

    public async Task<bool> DeleteMatchAsync(int id)
    {
        var match = await _matchRepository.GetByIdAsync(id);
        if (match is null)
            return false;

        _matchRepository.Delete(match);
        await _matchRepository.SaveChangesAsync();
        return true;
    }

    private static MatchDto MapToDto(Match match) => new()
    {
        Id = match.Id,
        HomeTeam = match.HomeTeam,
        AwayTeam = match.AwayTeam,
        KickoffUtc = match.KickoffUtc,
        Group = match.Group,
        HomeScore = match.HomeScore,
        AwayScore = match.AwayScore
    };
}