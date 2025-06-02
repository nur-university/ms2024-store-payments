using Payments.Application;
using Payments.Infrastructure;
using Payments.WebApi;
using Nur.Store2025.Observability;

var builder = WebApplication.CreateBuilder(args);

string serviceName = "payments.api";

builder.Host.UseLogging(serviceName, builder.Configuration);

// Add services to the container.
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment, serviceName)
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
