using Api.Configuration;
using Bll.Domain.Entities;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;
using Bll.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region servicesDI
builder.Services.AddTransient<ISimulationService, SimulationService>();

builder.Services.AddScoped<ITimeProvider, TimeProvider>();
builder.Services.AddScoped<IResults, Bll.Domain.Entities.Results>();
builder.Services.AddScoped<IResultManager, ResultManager>();
builder.Services.AddScoped<IResultManager, ResultManager>();
//builder.Services.AddTransient<IBufferManager, StandardBufferManager>();
builder.Services.AddTransient<IBufferManagerFactory, BufferManagerFactory>();
builder.Services.AddTransient<IDeviceManager, DeviceManager>();
builder.Services.AddTransient<ISourceManager, SourceManager>();
//builder.Services.AddScoped<StandardBufferManager>()
//    .AddScoped<IBufferManager, StandardBufferManager>(s => s.GetRequiredService<StandardBufferManager>());

//builder.Services.AddScoped<IBufferManager>(s =>
//    ActivatorUtilities.CreateInstance<StandardBufferManager>(s));
#endregion

builder.Services.AddMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();