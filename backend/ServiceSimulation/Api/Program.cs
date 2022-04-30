using Api.Configuration;
using Api.Extensions;
using Api.Validation;
using Bll.Domain.Entities;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;
using Bll.Domain.Models;
using Bll.Domain.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation(fv =>
{
    //fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
fv.RegisterValidatorsFromAssemblyContaining<InputParametersValidator>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region servicesDI
builder.Services.AddTransient<ISimulationService, SimulationService>();

builder.Services.AddScoped<ITimeProvider, TimeProvider>();
builder.Services.AddScoped<IFlowProvider, PoissonianFlowProvider>();

builder.Services.AddScoped<IResults, Bll.Domain.Entities.Results>();
builder.Services.AddScoped<IResultManager, ResultManager>();

builder.Services.AddTransient<IBufferManagerFactory, BufferManagerFactory>();
builder.Services.AddTransient<IDeviceManager, DeviceManager>();
builder.Services.AddTransient<ISourceManager, SourceManager>();

builder.Services.AddTransient<IValidator<InputParameters>, InputParametersValidator>();
#endregion

#region Mapper
builder.Services.AddMapper();
#endregion

#region CORS
builder.Services.AddCors(opts =>
{
    opts.AddPolicy(CorsPolicies.AllowRemoteFrontendWithCredentials);
});
#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();