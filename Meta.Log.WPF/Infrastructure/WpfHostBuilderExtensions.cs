using System.Windows;
using Meta.Log.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;

namespace Meta.Log.WPF.Infrastructure
{
    public static class WpfHostBuilderExtensions
    {
        //public static IHostBuilder ConfigureWpf(this IHostBuilder hostBuilder, Action<IWpfBuilder> configureDelegate = null)
        public static IHostBuilder ConfigureWpf(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                
                services.AddSingleton<MainWindow>();
                services.AddSingleton<IViewFor<MainViewModel>, MainWindow>(x => x.GetRequiredService<MainWindow>());
            });

            return hostBuilder;
        }

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
