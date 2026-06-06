using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;
using ShotCaller.Domain;

namespace ShotCaller.Application.Services;

public class PredictionService : IPredictionService
{
    private readonly IPredictionRepository _predictionRepository;
    private readonly IMatchRepository _matchRepository;

    public PredictionService(IPredictionRepository predictionRepository, IMatchRepository matchRepository)
    {
        _predictionRepository = predictionRepository;
        _matchRepository = matchRepository;
    }

    public async Task<IEnumerable<PredictionDto>> GetAllPredictionsAsync()
    {
        var predictions = await _predictionRepository.GetAllAsync();
        return predictions.Select(MapToDto);
    }

    public async Task<IEnumerable<PredictionDto>> GetPredictionsByMatchIdAsync(int matchId)
    {
        var predictions = await _predictionRepository.GetByMatchIdAsync(matchId);
        return predictions.Select(MapToDto);
    }

    public async Task<IEnumerable<PredictionDto>> GetPredictionsByUserAsync(string userName)
    {
        var predictions = await _predictionRepository.GetByUserNameAsync(userName);
        return predictions.Select(MapToDto);
    }

    public async Task<PredictionDto> CreatePredictionAsync(CreatePredictionDto dto)
    {
        var prediction = new Prediction
        {
            UserName = dto.UserName,
            MatchId = dto.MatchId,
            PredictedHomeScore = dto.PredictedHomeScore,
            PredictedAwayScore = dto.PredictedAwayScore,
            CreatedAt = DateTime.UtcNow
        };

        await _predictionRepository.AddAsync(prediction);
        await _predictionRepository.SaveChangesAsync();
        return MapToDto(prediction);
    }

    public async Task<PredictionDto?> UpdatePredictionAsync(int id, UpdatePredictionDto dto)
    {
        var prediction = await _predictionRepository.GetByIdAsync(id);
        if (prediction is null) return null;

        prediction.PredictedHomeScore = dto.PredictedHomeScore;
        prediction.PredictedAwayScore = dto.PredictedAwayScore;

        _predictionRepository.Update(prediction);
        await _predictionRepository.SaveChangesAsync();
        return MapToDto(prediction);
    }

    public async Task<bool> DeletePredictionAsync(int id)
    {
        var prediction = await _predictionRepository.GetByIdAsync(id);
        if (prediction is null) return false;

        _predictionRepository.Delete(prediction);
        await _predictionRepository.SaveChangesAsync();
        return true;
    }

    private static PredictionDto MapToDto(Prediction p) => new()
    {
        Id = p.Id,
        UserName = p.UserName,
        MatchId = p.MatchId,
        PredictedHomeScore = p.PredictedHomeScore,
        PredictedAwayScore = p.PredictedAwayScore,
        Points = p.Points,
        CreatedAt = p.CreatedAt
    };
}