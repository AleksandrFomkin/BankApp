using BankApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.UI.Dialogs
{
    public interface IMessageDialogService
    {
        public MessageDialogResult ShowYesNoDialog(string title, string message);
    }
}
