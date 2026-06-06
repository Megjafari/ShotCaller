using ShotCaller.Domain;

namespace ShotCaller.Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(ShotCallerDbContext context)
    {
        if (context.Matches.Any())
            return; // Redan seedat, gör inget

        var matches = new List<Match>
        {
            new() { HomeTeam = "Mexico",      AwayTeam = "South Africa", Group = "A", KickoffUtc = new DateTime(2026, 6, 11, 19, 0, 0, DateTimeKind.Utc) },
            new() { HomeTeam = "South Korea", AwayTeam = "Czechia",      Group = "A", KickoffUtc = new DateTime(2026, 6, 12, 2, 0, 0, DateTimeKind.Utc) },
            new() { HomeTeam = "Canada",      AwayTeam = "Bosnia and Herzegovina", Group = "B", KickoffUtc = new DateTime(2026, 6, 12, 19, 0, 0, DateTimeKind.Utc) },
            new() { HomeTeam = "United States", AwayTeam = "Paraguay",   Group = "D", KickoffUtc = new DateTime(2026, 6, 13, 1, 0, 0, DateTimeKind.Utc) },
            new() { HomeTeam = "Qatar",       AwayTeam = "Switzerland",  Group = "B", KickoffUtc = new DateTime(2026, 6, 13, 19, 0, 0, DateTimeKind.Utc) },
            new() { HomeTeam = "Brazil",      AwayTeam = "Morocco",      Group = "C", KickoffUtc = new DateTime(2026, 6, 13, 22, 0, 0, DateTimeKind.Utc) },
            new() { HomeTeam = "Haiti",       AwayTeam = "Scotland",     Group = "C", KickoffUtc = new DateTime(2026, 6, 14, 1, 0, 0, DateTimeKind.Utc) },
            new() { HomeTeam = "Spain",       AwayTeam = "Cape Verde",   Group = "H", KickoffUtc = new DateTime(2026, 6, 15, 17, 0, 0, DateTimeKind.Utc) },
        };

        context.Matches.AddRange(matches);
        context.SaveChanges();
    }
}