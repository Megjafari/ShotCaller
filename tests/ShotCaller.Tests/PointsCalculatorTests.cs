using ShotCaller.Application.Services;
using Xunit;

namespace ShotCaller.Tests;

public class PointsCalculatorTests
{
    [Fact]
    public void ExactResult_Win_Gives3Points()
    {
        // Tippade 2-1, blev 2-1
        var points = PointsCalculator.Calculate(2, 1, 2, 1);
        Assert.Equal(3, points);
    }

    [Fact]
    public void ExactResult_Draw_Gives3Points()
    {
        // Tippade 1-1, blev 1-1
        var points = PointsCalculator.Calculate(1, 1, 1, 1);
        Assert.Equal(3, points);
    }

    [Fact]
    public void CorrectWinner_WrongScore_Gives1Point()
    {
        // Tippade 2-1, blev 3-0 (båda hemmaseger)
        var points = PointsCalculator.Calculate(2, 1, 3, 0);
        Assert.Equal(1, points);
    }

    [Fact]
    public void CorrectDraw_WrongScore_Gives1Point()
    {
        // Tippade 1-1, blev 2-2 (båda oavgjort)
        var points = PointsCalculator.Calculate(1, 1, 2, 2);
        Assert.Equal(1, points);
    }

    [Fact]
    public void WrongOutcome_Gives0Points()
    {
        // Tippade 2-1 (hemmaseger), blev 1-2 (bortaseger)
        var points = PointsCalculator.Calculate(2, 1, 1, 2);
        Assert.Equal(0, points);
    }
}