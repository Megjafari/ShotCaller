using System;
using System.Collections.Generic;
using System.Text;

namespace ShotCaller.Application.DTOs
{
    public class CreatePredictionDto
    {
        public string UserName { get; set; } = string.Empty;
        public int MatchId { get; set; }
        public int PredictedHomeScore { get; set; }
        public int PredictedAwayScore { get; set; }
    }
}
