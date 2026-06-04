namespace ShotCaller.Domain;

public class Match
{
    public int Id { get; set; }
    public string HomeTeam { get; set; } = string.Empty;
    public string AwayTeam { get; set; } = string.Empty;
    public DateTime KickoffUtc { get; set; }
    public string Group { get; set; } = string.Empty;
    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
}