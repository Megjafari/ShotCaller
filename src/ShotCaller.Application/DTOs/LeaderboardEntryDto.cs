namespace ShotCaller.Application.DTOs;

public class LeaderboardEntryDto
{
    public string UserName { get; set; } = string.Empty;
    public int TotalPoints { get; set; }
    public int PredictionCount { get; set; }
}

