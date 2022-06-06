using BankApp.UI.Views;

namespace BankApp.UI.Dialogs
{
    public class AddAccountDialogService : ICustomDialogService<AddAccountWindow>
    {
        public void ShowDialog()
        {
            var addClientWindow = new AddAccountWindow();
            addClientWindow.ShowDialog();
        }
    }
}
