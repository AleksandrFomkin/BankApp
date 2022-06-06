using BankApp.Model.ValueObjects;
using BankApp.UI.Core;

namespace BankApp.UI.Models
{
    public class AddressModel : BaseModel<Address>
    {
        public string Country 
        {
            get => GetValue<string>();
            set => SetValue(value); 
        }

        public string City 
        { 
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Street 
        { 
            get => GetValue<string>();
            set => SetValue(value);
        }

        public AddressModel(Address model) : base(model)
        {

        }
    }
}
