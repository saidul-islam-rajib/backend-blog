using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sober.Api.Common.Mappings;
using Sober.Api.ErrorHandling.ProlemDetailFactory;

namespace Sober.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, SoberProblemDetailsFactory>();

            services.AddMappings();
            return services;
        }
    }
}
