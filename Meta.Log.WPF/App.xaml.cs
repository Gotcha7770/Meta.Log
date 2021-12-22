using Meta.Log.WPF.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Windows;
using Meta.Log.Core.ViewModels;
using ReactiveUI;

namespace Meta.Log.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureSplat()
                .ConfigureServices((context, services) => { })
                .ConfigureLogging((context, logging) => { logging.AddSerilog(); })
                .StartWith<MainWindow, MainViewModel>()
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host.Start();

            var mainWindow = _host.Services.GetService<ReactiveWindow<MainViewModel>>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                _host.StopAsync(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();
            }
        }
    }
}