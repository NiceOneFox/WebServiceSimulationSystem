using Bll.Domain.Entities;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;
using Bll.Domain.Services;
using Buffer = Bll.Domain.Entities.Buffer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region servicesDI
builder.Services.AddTransient<ISimulationService, SimulationService>();

builder.Services.AddTransient<ITimeProvider, TimeProvider>();
builder.Services.AddTransient<IBuffer, Buffer>();
builder.Services.AddTransient<IBufferManager, StandardBufferManager>();
builder.Services.AddTransient<IBufferManagerFactory, BufferManagerFactory>();
builder.Services.AddTransient<IDevice, Device>();
builder.Services.AddTransient<ISource, Source>();

#endregion

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