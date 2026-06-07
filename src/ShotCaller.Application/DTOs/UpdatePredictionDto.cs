using System;
using System.Collections.Generic;
using System.Text;

namespace ShotCaller.Application.DTOs
{
    public class UpdatePredictionDto
    {
        public int PredictedHomeScore { get; set; }
        public int PredictedAwayScore { get; set; }
    }
}
