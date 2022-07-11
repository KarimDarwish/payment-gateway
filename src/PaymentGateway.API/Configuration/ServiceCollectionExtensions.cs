using System.ComponentModel;
using System.Reflection;
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
                TermsOfService = new Uri("https://github.com/KarimDarwish/checkout-payment-gateway"),
                Contact = new OpenApiContact
                {
                    Name = "Karim Darwish",
                    Url = new Uri("https://github.com/KarimDarwish/checkout-payment-gateway")
                },
                Description =
                    "A payment gateway that allows merchants to offer their shoppers a secure way to pay for their products",
            });

            options.CustomSchemaIds(type =>
                type.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ??
                type.Name);

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}