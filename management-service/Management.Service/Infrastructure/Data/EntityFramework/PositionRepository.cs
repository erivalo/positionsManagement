using Management.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal class PositionRepository : RepositoryContext, IPositionStore
{
  public PositionRepository(DbContextOptions<RepositoryContext> options) : base(options)
  {
  }

  public async Task CreatePosition(Position position)
  {
    Positions.Add(position);
    await SaveChangesAsync();
  }

  public async Task<Position?> GetById(int positionId)
  {
    return await Positions.FirstOrDefaultAsync(p => p.Id == positionId);
  }
}