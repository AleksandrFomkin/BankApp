using BankApp.Model.Entities;
using BankApp.Model.Enums;
using BankApp.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.UI.Models
{
    public class AccountModel : BaseModel<Account>
    {
        public AccountModel(Account model) : base(model)
        {

        }

        public int Balance 
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        public int AccountNumber
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        public AccountType AccountType
        {
            get => GetValue<AccountType>();
            set => SetValue(value);
        }
    }
}
