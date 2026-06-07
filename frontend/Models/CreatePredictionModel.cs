namespace frontend.Models;

public class CreatePredictionModel
{
    public string UserName { get; set; } = "";
    public int MatchId { get; set; }
    public int PredictedHomeScore { get; set; }
    public int PredictedAwayScore { get; set; }
}