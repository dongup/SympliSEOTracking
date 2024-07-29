using Microsoft.Extensions.DependencyInjection;

namespace SympliSEOTracking.Core;

public static class IocExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<BingSearchResultHandler>();
        serviceCollection.AddTransient<GoogleSearchResultHandler>();
        
        // Register a factory to resolve the correct implementation based on criteria
        serviceCollection.AddTransient<Func<string, ISearchResultHandler?>>(serviceProvider => 
        {
            return key =>
            {
                return key switch
                {
                    "Bing" => serviceProvider.GetService<BingSearchResultHandler>()!,
                    "Google" => serviceProvider.GetService<GoogleSearchResultHandler>()!,
                    _ => null
                };
            };
        });
        return serviceCollection;
    }
}