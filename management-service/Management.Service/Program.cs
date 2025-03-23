using Management.Service.Endpoints;
using Management.Service.Infrastructure.Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlLiteDataStore(builder.Configuration);

var app = builder.Build();

app.RegisterEndpoints();
if (app.Environment.IsDevelopment())
{
  app.MigrateDatabase();
}

app.UseHttpsRedirection();

app.Run();
