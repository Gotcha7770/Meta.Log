using Meta.Log.WPF.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Windows;

namespace Meta.Log.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host
                .CreateDefaultBuilder()
                //.UseServiceProviderFactory(new SplatServiceProviderFactory())
                .ConfigureSplat()
                .ConfigureServices((context, services) =>
                {
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddSerilog();
                })
                //.UseSerilog()
                .ConfigureWpf()
                .Build();

            // var container = _host.Services;
            // container.UseMicrosoftDependencyResolver();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}
