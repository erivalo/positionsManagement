using Microsoft.EntityFrameworkCore;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal static class RepositoryContextSeed
{
  public static void MigrateDatabase(this WebApplication webApp)
  {
    using var scope = webApp.Services.CreateScope();
    using var repositoryContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
    repositoryContext.Database.Migrate();
  }
}