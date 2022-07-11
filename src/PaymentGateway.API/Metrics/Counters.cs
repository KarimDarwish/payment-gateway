using Prometheus;

namespace PaymentGateway.API.Metrics;

public class Counters
{
    public static readonly Counter PaymentsProcessedCounter = Prometheus.Metrics
        .CreateCounter("payment_gateway_payments_processed_total", "Number of processed payments",
            new CounterConfiguration
            {
                LabelNames = new[] {"Currency"}
            });

    public static readonly Counter BankRequestsCounter = Prometheus.Metrics
        .CreateCounter("payment_gateway_bank_requests_total", "Total number of requests to the bank");

    public static readonly Counter BankRequestsRateLimitCounter = Prometheus.Metrics
        .CreateCounter("payment_gateway_bank_requests_failed", "Number of failed requests to the bank");
}