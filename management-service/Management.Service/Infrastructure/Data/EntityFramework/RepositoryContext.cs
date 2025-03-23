using Management.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal class RepositoryContext : DbContext
{
  public RepositoryContext(DbContextOptions<RepositoryContext> options)
    : base(options)
  {
  }

  public DbSet<Position> Positions { get; set; }
  public DbSet<Department> Departments { get; set; }
  public DbSet<Recruiter> Recruiters { get; set; }
  public DbSet<PositionStatus> PositionsStatuses { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new PositionConfiguration());
    modelBuilder.ApplyConfiguration(new PositionStatusConfiguration());
    modelBuilder.ApplyConfiguration(new RecruiterConfiguration());
    modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
  }
}