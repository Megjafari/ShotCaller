using NSubstitute;
using ShotCaller.Application.DTOs;
using ShotCaller.Application.Interfaces;
using ShotCaller.Application.Services;
using ShotCaller.Domain;
using Xunit;

namespace ShotCaller.Tests;

public class MatchServiceTests
{
    [Fact]
    public async Task UpdateMatchResult_ScoresAllPredictionsOnMatch()
    {
        // Arrange
        var matchRepo = Substitute.For<IMatchRepository>();
        var predictionRepo = Substitute.For<IPredictionRepository>();

        var match = new Match { Id = 1, HomeTeam = "Sweden", AwayTeam = "Brazil" };
        matchRepo.GetByIdAsync(1).Returns(match);

        var predictions = new List<Prediction>
        {
            new() { Id = 1, MatchId = 1, PredictedHomeScore = 2, PredictedAwayScore = 1 }, // exakt → 3
            new() { Id = 2, MatchId = 1, PredictedHomeScore = 3, PredictedAwayScore = 0 }, // rätt vinnare → 1
            new() { Id = 3, MatchId = 1, PredictedHomeScore = 0, PredictedAwayScore = 2 }  // fel → 0
        };
        predictionRepo.GetByMatchIdAsync(1).Returns(predictions);

        var service = new MatchService(matchRepo, predictionRepo);

        // Act: matchen slutade 2-1
        await service.UpdateMatchResultAsync(1, new UpdateMatchResultDto { HomeScore = 2, AwayScore = 1 });

        // Assert
        Assert.Equal(3, predictions[0].Points);
        Assert.Equal(1, predictions[1].Points);
        Assert.Equal(0, predictions[2].Points);
        await matchRepo.Received(1).SaveChangesAsync();
    }
}