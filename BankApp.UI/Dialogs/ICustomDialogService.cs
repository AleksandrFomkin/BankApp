using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.UI.Dialogs
{
    public interface ICustomDialogService<TDialog>
    {
        void ShowDialog();
    }
}
