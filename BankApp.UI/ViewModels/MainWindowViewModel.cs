using BankApp.UI.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;

namespace BankApp.UI.ViewModels
{
    public interface IMainWindowViewModel { }
    public class MainWindowViewModel : Bindable, IMainWindowViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        private Bindable? currentViewModel;
        public Bindable? CurrentViewModel 
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            CurrentViewModel = _serviceProvider.GetService<IClientsWindowViewModel>() as Bindable;
            InitCommands();
        }

        public ICommand? OpenClientsViewCommand { get; private set; }
        public ICommand? OpenAboutViewCommand { get; private set; }

        private void InitCommands()
        {
            OpenClientsViewCommand = new RelayCommand(OnOpenClientsViewExecute);
            OpenAboutViewCommand = new RelayCommand(OnOpenAboutViewExecute);
        }

        private void OnOpenAboutViewExecute(object obj)
        {
            CurrentViewModel = _serviceProvider.GetService<IAboutWindowViewModel>() as AboutWindowViewModel;
        }

        private void OnOpenClientsViewExecute(object obj)
        {
            CurrentViewModel = _serviceProvider.GetService<IClientsWindowViewModel>() as ClientsWindowViewModel;
        }
    }
}
