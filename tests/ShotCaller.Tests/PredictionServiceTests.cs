using NSubstitute;
using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;
using ShotCaller.Application.Services;
using ShotCaller.Domain;

namespace ShotCaller.Tests;

public class PredictionServiceTests
{
    private readonly IPredictionRepository _predictionRepository;
    private readonly IMatchRepository _matchRepository;
    private readonly PredictionService _predictionService;

    public PredictionServiceTests()
    {
        _predictionRepository = Substitute.For<IPredictionRepository>();
        _matchRepository = Substitute.For<IMatchRepository>();
        _predictionService = new PredictionService(_predictionRepository, _matchRepository);
    }

    [Fact]
    public async Task CreatePredictionAsync_ReturnsPredictionDto()
    {
        // Arrange
        var dto = new CreatePredictionDto
        {
            UserName = "Dadir",
            MatchId = 1,
            PredictedHomeScore = 2,
            PredictedAwayScore = 1
        };

        _predictionRepository.AddAsync(Arg.Any<Prediction>()).Returns(Task.CompletedTask);
        _predictionRepository.SaveChangesAsync().Returns(1);

        // Act
        var result = await _predictionService.CreatePredictionAsync(dto);

        // Assert
        Assert.Equal("Dadir", result.UserName);
        Assert.Equal(1, result.MatchId);
        Assert.Equal(2, result.PredictedHomeScore);
        Assert.Equal(1, result.PredictedAwayScore);
    }

    [Fact]
    public async Task GetPredictionsByMatchIdAsync_ReturnsCorrectPredictions()
    {
        // Arrange
        var predictions = new List<Prediction>
        {
            new() { Id = 1, UserName = "Dadir", MatchId = 1, PredictedHomeScore = 2, PredictedAwayScore = 0 },
            new() { Id = 2, UserName = "Meg", MatchId = 1, PredictedHomeScore = 1, PredictedAwayScore = 1 }
        };

        _predictionRepository.GetByMatchIdAsync(1).Returns(predictions);

        // Act
        var result = await _predictionService.GetPredictionsByMatchIdAsync(1);

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task DeletePredictionAsync_ReturnsFalse_WhenNotFound()
    {
        // Arrange
        _predictionRepository.GetByIdAsync(99).Returns((Prediction?)null);

        // Act
        var result = await _predictionService.DeletePredictionAsync(99);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task UpdatePredictionAsync_ReturnsNull_WhenNotFound()
    {
        // Arrange
        _predictionRepository.GetByIdAsync(99).Returns((Prediction?)null);

        // Act
        var result = await _predictionService.UpdatePredictionAsync(99, new UpdatePredictionDto());

        // Assert
        Assert.Null(result);
    }
}
