using Microsoft.EntityFrameworkCore;
using ShotCaller.Application.Interfaces;
using ShotCaller.Domain;
using ShotCaller.Infrastructure.Data;

namespace ShotCaller.Infrastructure.Repositories;

public class PredictionRepository : GenericRepository<Prediction>, IPredictionRepository
{
    private readonly ShotCallerDbContext _context;

    public PredictionRepository(ShotCallerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Prediction>> GetByMatchIdAsync(int matchId)
    {
        return await _context.Predictions
            .Where(p => p.MatchId == matchId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Prediction>> GetByUserNameAsync(string userName)
    {
        return await _context.Predictions
            .Where(p => p.UserName == userName)
            .ToListAsync();
    }
}