using BankApp.Model.Entities;
using BankApp.Model.ValueObjects;
using BankApp.UI.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BankApp.UI.Models
{
    public class ClientModel : BaseModel<Client>
    {
        public string Name 
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string NameOriginalValue => GetOriginalValue<string>(nameof(Name));

        public bool NameIsChanged => GetIsChanged(nameof(Name));

        public string SecondName 
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string SecondNameOriginalValue => GetOriginalValue<string>(nameof(Name));

        public bool SecondNameIsChanged => GetIsChanged(nameof(Name));

        public string FullName => $"{Name} {SecondName}";

        public AddressModel Address { get; private set; }

        public ObservableCollection<AccountModel> Accounts { get; set; }

        public ClientModel(Client client) : base(client)
        {
            if (client.Accounts == null)
            {
                throw new ArgumentException(nameof(client.Accounts));
            }
            Address = new AddressModel(Model.Address);
            Accounts = new ObservableCollection<AccountModel>(client.Accounts.Select(e => new AccountModel(e)));        
        }
    }
}
