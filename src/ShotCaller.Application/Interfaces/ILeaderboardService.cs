using ShotCaller.Application.DTOs;

namespace ShotCaller.Application.Interfaces
{
    public interface ILeaderboardService
    {
        Task<IEnumerable<LeaderboardEntryDto>> GetLeaderboardAsync();
    }
}
