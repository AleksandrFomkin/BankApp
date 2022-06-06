using BankApp.UI.Models;

namespace BankApp.UI.ViewModels
{
    public abstract class IAddClientWindowViewModel 
    {
        public virtual ClientModel? Client { get; set; }
    }
    public class AddClientWindowViewModel : IAddClientWindowViewModel
    {

    }
}
