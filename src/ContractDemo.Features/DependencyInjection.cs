using ContractDemo.Features.LeadScoring;
using Microsoft.Extensions.DependencyInjection;

namespace ContractDemo.Features;

public static class DependencyInjection
{
    public static IServiceCollection AddFeatureServices(this IServiceCollection services)
    {
        services.AddScoped<ILeadScoringService, DefaultLeadScoringService>();
        return services;
    }
}
