using Microsoft.EntityFrameworkCore;

namespace Management.Service.Infrastructure.Data.EntityFramework;
public static class EntityFrameworkExtensions
{
  public static void AddSqlLiteDataStore(
    this IServiceCollection services,
    IConfigurationManager configuration)
  {
    services.AddDbContext<RepositoryContext>(options =>
      options.UseSqlite(configuration.GetConnectionString("Default")));

    services.AddScoped<IPositionRepository, PositionRepository>();
  }

}