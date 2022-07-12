using System.Reflection;
using MediatR;
using PaymentGateway.API.Configuration;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Infrastructure.Repositories;
using PaymentGateway.MockBank.Services;
using PaymentGateway.MockBank.Services.RandomNumber;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
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
app.Run();