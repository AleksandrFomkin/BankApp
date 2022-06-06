using BankApp.Model.Entities;
using BankApp.Persistence.Abstract;
using BankApp.Persistence.Repositories;
using BankApp.UI.Dialogs;
using BankApp.UI.ViewModels;
using BankApp.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BankApp.UI
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            services.AddScoped<IRepository<Client>, ClientRepository>();
            services.AddScoped<IMessageDialogService, MessageDialogService>();
            services.AddScoped<IClientsWindowViewModel, ClientsWindowViewModel>();
            services.AddScoped<IAboutWindowViewModel, AboutWindowViewModel>();
            services.AddScoped<ICustomDialogService<AddAccountWindow>, AddAccountDialogService>();
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
            base.OnStartup(e);
        }
    }
}
