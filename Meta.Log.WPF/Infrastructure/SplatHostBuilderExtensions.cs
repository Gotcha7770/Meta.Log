using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace Meta.Log.WPF.Infrastructure
{
    public static class SplatHostBuilderExtensions
    {
        public static IHostBuilder ConfigureSplat(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.UseMicrosoftDependencyResolver();
                var resolver = Locator.CurrentMutable;
                resolver.InitializeSplat();
                resolver.InitializeReactiveUI();
            });

            return hostBuilder;
        }
    }
}
