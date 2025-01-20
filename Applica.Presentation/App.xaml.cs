
using Applica.Infrastructure.Context;
using Applica.Presentation.Services;
using Applica.Presentation.ViewModels;
using Applica.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Applica.Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
/// 


public partial class App : Application
{
    public static ServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();
        InitializeComponent();
    }

    private void ConfigureServices(IServiceCollection services)
    {

        services.AddTransient<MongoContext>();

        services.AddTransient<CompanyService>();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
