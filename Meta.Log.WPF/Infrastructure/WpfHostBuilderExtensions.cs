using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;

namespace Meta.Log.WPF.Infrastructure
{
    public static class WpfHostBuilderExtensions
    {
        public static IHostBuilder StartWith<TView, TViewModel>(this IHostBuilder hostBuilder) 
            where TView : ReactiveWindow<TViewModel> 
            where TViewModel : ReactiveObject
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<TViewModel>();
                services.AddSingleton<ReactiveWindow<TViewModel>, TView>();
            });

            return hostBuilder;
        }
    }
}
