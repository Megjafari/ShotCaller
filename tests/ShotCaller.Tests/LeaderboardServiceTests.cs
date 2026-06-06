using NSubstitute;
using ShotCaller.Application.Interfaces;
using ShotCaller.Application.Services;
using ShotCaller.Domain;

namespace ShotCaller.Tests;

public class LeaderboardServiceTests
{
    private readonly IPredictionRepository _predictionRepository;
    private readonly LeaderboardService _leaderboardService;

    public LeaderboardServiceTests()
    {
        _predictionRepository = Substitute.For<IPredictionRepository>();
        _leaderboardService = new LeaderboardService(_predictionRepository);
    }

    [Fact]
    public async Task GetLeaderboardAsync_ReturnsSortedByTotalPoints()
    {
        // Arrange
        var predictions = new List<Prediction>
        {
            new() { UserName = "Dadir", Points = 3 },
            new() { UserName = "Dadir", Points = 1 },
            new() { UserName = "Megdad", Points = 3 },
        };

        _predictionRepository.GetAllAsync().Returns(predictions);

        // Act
        var result = (await _leaderboardService.GetLeaderboardAsync()).ToList();

        // Assert
        Assert.Equal("Dadir", result[0].UserName);
        Assert.Equal(4, result[0].TotalPoints);
        Assert.Equal("Megdad", result[1].UserName);
        Assert.Equal(3, result[1].TotalPoints);
    }

    [Fact]
    public async Task GetLeaderboardAsync_CountsPredictionsPerUser()
    {
        // Arrange
        var predictions = new List<Prediction>
        {
            new() { UserName = "Dadir", Points = 3 },
            new() { UserName = "Dadir", Points = 0 },
            new() { UserName = "Megdad", Points = 1 },
        };

        _predictionRepository.GetAllAsync().Returns(predictions);

        // Act
        var result = (await _leaderboardService.GetLeaderboardAsync()).ToList();

        // Assert
        Assert.Equal(2, result.First(r => r.UserName == "Dadir").PredictionCount);
        Assert.Equal(1, result.First(r => r.UserName == "Megdad").PredictionCount);
    }
}