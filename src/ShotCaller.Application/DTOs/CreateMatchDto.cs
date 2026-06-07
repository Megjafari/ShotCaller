using System;
using System.Collections.Generic;
using System.Text;

namespace ShotCaller.Application.DTOs
{
    public class CreateMatchDto
    {
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public DateTime KickoffUtc { get; set; }
        public string Group { get; set; } = string.Empty;
    }
}
