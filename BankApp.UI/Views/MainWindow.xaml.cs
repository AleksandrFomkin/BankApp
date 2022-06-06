using BankApp.UI.ViewModels;
using System.Windows;

namespace BankApp.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            DataContext = mainWindowViewModel;
            InitializeComponent();
        }
    }
}
