using System;
using System.Collections.Generic;
using System.Text;
using ShotCaller.Domain;

namespace ShotCaller.Application.Interfaces
{
    public interface IPredictionRepository : IGenericRepository<Prediction>
    {
        Task<IEnumerable<Prediction>> GetByMatchIdAsync(int matchId);
        Task<IEnumerable<Prediction>> GetByUserNameAsync(string userName);
    }
}
