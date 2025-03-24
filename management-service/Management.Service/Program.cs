using Management.Service.Endpoints;
using Management.Service.Infrastructure.Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlLiteDataStore(builder.Configuration);
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "MyPolicy",
  builder =>
  {
    builder.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader();
  });
});

var app = builder.Build();

app.RegisterEndpoints();
if (app.Environment.IsDevelopment())
{
  app.MigrateDatabase();
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.Run();
