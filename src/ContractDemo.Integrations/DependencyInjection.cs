using ContractDemo.Integrations.Leads;
using Microsoft.Extensions.DependencyInjection;

namespace ContractDemo.Integrations;

public static class DependencyInjection
{
    public static IServiceCollection AddIntegrationServices(this IServiceCollection services)
    {
        services.AddScoped<ILeadSubmissionClient, MockLeadSubmissionClient>();
        return services;
    }
}
