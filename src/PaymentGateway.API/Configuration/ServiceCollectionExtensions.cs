using Microsoft.OpenApi.Models;

namespace PaymentGateway.API.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Payment Gateway",
                Description =
                    "A payment gateway that allows merchants to offer their shoppers a secure way to pay for their products",
            });
        });
    }
}