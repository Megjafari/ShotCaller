namespace ShotCaller.Domain;

public class Prediction
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;
    public int PredictedHomeScore { get; set; }
    public int PredictedAwayScore { get; set; }
    public int? Points { get; set; }
    public DateTime CreatedAt { get; set; }
}