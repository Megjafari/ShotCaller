using ShotCaller.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShotCaller.Application.Interfaces
{
    public interface IPredictionService
    {
        Task<IEnumerable<PredictionDto>> GetAllPredictionsAsync();
        Task<IEnumerable<PredictionDto>> GetPredictionsByMatchIdAsync(int matchId);
        Task<IEnumerable<PredictionDto>> GetPredictionsByUserAsync(string userName);
        Task<PredictionDto> CreatePredictionAsync(CreatePredictionDto dto);
        Task<PredictionDto?> UpdatePredictionAsync(int id, UpdatePredictionDto dto);
        Task<bool> DeletePredictionAsync(int id);
    }
}
