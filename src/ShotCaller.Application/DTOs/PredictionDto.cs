using System;
using System.Collections.Generic;
using System.Text;

namespace ShotCaller.Application.DTOs
{
    public class PredictionDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int MatchId { get; set; }
        public int PredictedHomeScore { get; set; }
        public int PredictedAwayScore { get; set; }
        public int? Points { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
