using ShotCaller.Application.Interfaces;
using ShotCaller.Domain;
using ShotCaller.Infrastructure.Data;

namespace ShotCaller.Infrastructure.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository (ShotCallerDbContext context) : base (context) { }
    }
}
