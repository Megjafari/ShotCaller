namespace frontend.Models;

public class MatchModel
{
    public int Id { get; set; }
    public string HomeTeam { get; set; } = "";
    public string AwayTeam { get; set; } = "";
    public DateTime KickoffUtc { get; set; }
    public string Group { get; set; } = "";
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }
}