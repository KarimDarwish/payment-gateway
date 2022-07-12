using System.Reflection;
using MediatR;
using PaymentGateway.API.Configuration;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Infrastructure.Repositories;
using PaymentGateway.MockBank.Services;
using PaymentGateway.MockBank.Services.RandomNumber;
using Prometheus;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddHealthChecks();
builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IRandomNumberGenerator, RandomNumberGenerator>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

var app = builder.Build();

app.UseMetricServer();
app.MapHealthChecks("/health");
app.UseHttpMetrics();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

app.UseSerilogRequestLogging();

try
{
    Log.Information("Starting web host");
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}