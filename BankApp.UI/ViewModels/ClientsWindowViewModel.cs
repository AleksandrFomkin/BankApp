using BankApp.Model.Entities;
using BankApp.Persistence.Abstract;
using BankApp.UI.Core;
using BankApp.UI.Dialogs;
using BankApp.UI.Models;
using BankApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp.UI.ViewModels
{
    public interface IClientsWindowViewModel { }
    public class ClientsWindowViewModel : Bindable, IClientsWindowViewModel
    {
        /// <summary>
        /// Коллекция клиентов банка
        /// </summary>
        public ObservableCollection<ClientModel> BankClients { get; set; } = new ObservableCollection<ClientModel>();

        private readonly IRepository<Client> _clientRepository;
        private readonly IMessageDialogService _messageDialogService;
        private readonly ICustomDialogService<AddAccountWindow> _addAccountDialog;

        /// <summary>
        /// Выбранный в данный момент клиент
        /// </summary>
        private ClientModel? _selectedClient;
        public ClientModel? SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }

        private AccountModel? _selectedAccount;
        public AccountModel? SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
            }
        }

        private ICommand? _deleteAccountCommand;

        public ICommand? DeleteAccountCommand
        {
            get => _deleteAccountCommand;
        }

        private ICommand? _addAccountCommand;
        public ICommand? AddAccountCommand
        {
            get => _addAccountCommand;
        }


        public ClientsWindowViewModel(IRepository<Client> clientRepository, IMessageDialogService messageDialogService, ICustomDialogService<AddAccountWindow> addAccountDialog)
        {
            _clientRepository = clientRepository;
            _messageDialogService = messageDialogService;
            _addAccountDialog = addAccountDialog;
            BankClients = new ObservableCollection<ClientModel>(_clientRepository.GetList().Select(e => new ClientModel(e)));
            InitCommands();
        }

        private void InitCommands()
        {
            _deleteAccountCommand = new RelayCommand(OnDeleteAccountExecute, OnDeleteAccountCanExecute);
            _addAccountCommand = new RelayCommand(OnAddAccountExecute, OnAddAccountCanExecute);
        }

        private bool OnAddAccountCanExecute(object arg)
        {
            return _selectedAccount != null;
        }

        private void OnAddAccountExecute(object obj)
        {
            _addAccountDialog.ShowDialog();
        }

        private bool OnDeleteAccountCanExecute(object arg)
        {
            return _selectedAccount != null;
        }

        private void OnDeleteAccountExecute(object obj)
        {
            if (SelectedAccount != null)
            {
                var dialogResult = _messageDialogService.ShowYesNoDialog("Предупреждение", "Вы действительно хотите удалить этот счет ?");
                if (dialogResult == MessageDialogResult.Yes)
                {
                    SelectedClient?.Accounts.Remove(SelectedAccount);
                }
            }
        }
    }
}
