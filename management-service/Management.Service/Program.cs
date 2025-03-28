using FluentValidation;
using Management.Service.Dtos;
using Management.Service.Endpoints;
using Management.Service.Infrastructure.Data.EntityFramework;
using Management.Service.Infrastructure.RabbitMq;
using Management.Service.Validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRabbitMqEventBus(builder.Configuration);
builder.Services.AddSqlLiteDataStore(builder.Configuration);
builder.Services.AddScoped<IValidator<CreatePositionRequest>, CreatePositionRequestValidator>();
builder.Services.AddHealthChecks();
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
app.MapHealthChecks("health");

app.Run();
