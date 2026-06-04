using ShotCaller.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShotCaller.Application.Interfaces
{
    public interface IMatchService
    {
        Task<IEnumerable<MatchDto>> GetAllMatchesAsync();
        Task<MatchDto?> GetMatchByIdAsync(int id);
        Task<MatchDto> CreateMatchAsync(CreateMatchDto dto);
        Task<MatchDto?> UpdateMatchResultAsync(int id, UpdateMatchResultDto dto);
        Task<bool> DeleteMatchAsync(int id);
    }
}
