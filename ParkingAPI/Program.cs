using AppCore.Interfaces;
using AppCore.Module;
using AppCore.Services;
using Domain.Interfaces;
using Infrastructure.Memory;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAppCoreModule(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Repositories
builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
builder.Services.AddSingleton<IParkingGateRepository, InMemoryParkingGateRepository>();
builder.Services.AddSingleton<IParkingSessionRepository, InMemoryParkingSessionRepository>();
builder.Services.AddSingleton<IParkingTariffRepository, InMemoryParkingTariffRepository>();
builder.Services.AddSingleton<ICameraCaptureRepository, InMemoryCameraCaptureRepository>();

// UnitOfWork
builder.Services.AddSingleton<IParkingUnitOfWork, MemoryParkingUnitOfWork>();

// Services
builder.Services.AddSingleton<IParkingGateService, MemoryParkingGateService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("ParkingAPI");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/scalar/v1"));

app.Run();