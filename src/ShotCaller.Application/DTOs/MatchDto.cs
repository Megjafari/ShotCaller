using System;
using System.Collections.Generic;
using System.Text;

namespace ShotCaller.Application.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public DateTime KickoffUtc { get; set; }
        public string Group { get; set; } = string.Empty;
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
    }
}
