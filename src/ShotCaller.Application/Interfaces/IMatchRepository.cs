using ShotCaller.Domain;

namespace ShotCaller.Application.Interfaces;

public interface IMatchRepository : IGenericRepository<Match>
{
    // IgenericRepository already provides basic CRUD operations, so we can add any match-specific methods here if needed in the future.
}