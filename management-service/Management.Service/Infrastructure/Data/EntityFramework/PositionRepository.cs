using Management.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal class PositionRepository : RepositoryBase<Position>, IPositionRepository
{
  public PositionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
  {
  }

  public async Task CreatePosition(Position position)
  {
    Create(position);
    await RepositoryContext.SaveChangesAsync();
  }

  public async Task<Position?> GetById(int positionId, bool trackChanges) =>
    await FindByCondition(p => p.Id == positionId, trackChanges).SingleOrDefaultAsync();

  public async Task<List<Position>> GetPositions(bool trackChanges)
  {
    return await FindAll(trackChanges)
      .OrderBy(p => p.Title)
      .ToListAsync();
  }

  public async Task UpdatePosition(Position position)
  {
    await RepositoryContext.SaveChangesAsync();
  }
}