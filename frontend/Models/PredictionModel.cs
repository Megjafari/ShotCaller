namespace frontend.Models;

public class PredictionModel
{
    public int Id { get; set; }
    public string UserName { get; set; } = "";
    public int MatchId { get; set; }
    public int PredictedHomeScore { get; set; }
    public int PredictedAwayScore { get; set; }
    public int? Points { get; set; }
    public DateTime CreatedAt { get; set; }
}