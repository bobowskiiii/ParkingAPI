using AppCore.Interfaces;
using AppCore.Mappings;
using AppCore.Services;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddAutoMapper((Action<IMapperConfigurationExpression>)null , typeof(Program).Assembly);


//Repositories
builder.Services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
builder.Services.AddSingleton<IParkingGateRepository, InMemoryParkingGateRepository>();
builder.Services.AddSingleton<IParkingSessionRepository, InMemoryParkingSessionRepository>();
builder.Services.AddSingleton<IParkingTariffRepository, InMemoryParkingTariffRepository>();
builder.Services.AddSingleton<ICameraCaptureRepository, InMemoryCameraCaptureRepository>();

//UnitOfWork
builder.Services.AddSingleton<IParkingUnitOfWork, MemoryParkingUnitOfWork>();

//Services
builder.Services.AddSingleton<IParkingGateService, MemoryParkingGateService>();

var app = builder.Build();

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//Redirect to swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();