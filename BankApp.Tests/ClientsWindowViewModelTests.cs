using BankApp.Model.Entities;
using BankApp.Model.Enums;
using BankApp.Model.ValueObjects;
using BankApp.Persistence.Abstract;
using BankApp.UI.Dialogs;
using BankApp.UI.ViewModels;
using BankApp.UI.Views;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BankApp.Tests
{
    public class ClientsWindowViewModelTests
    {
        ClientsWindowViewModel? viewModel;

        readonly IList<Client> _clients = new List<Client>();

        [SetUp]
        public void Setup()
        {
            _clients.Add(new Client("Александр", new Address("Россия", "Санкт-Петербург", "Подольская ул."))
            {
                SecondName = "Фомкин",
                Accounts = new List<Account>
                {
                    new Account{ Balance = 10000, AccountType = AccountType.Deposit},
                    new Account{ Balance = 4000, AccountType = AccountType.NonDeposit},
                    new Account{ Balance = 5000, AccountType = AccountType.Deposit}
                },
            });
            _clients.Add(new Client("Саша", new Address("Россия", "Санкт-Петербург", "Подольская ул."))
            {
                SecondName = "Фомич",
                Accounts = new List<Account>
                {
                    new Account{ Balance = 40000, AccountType = AccountType.Deposit}
                },
            });

            var repositoryMock = new Mock<IRepository<Client>>();
            repositoryMock.Setup(x => x.GetList()).Returns(_clients);


            var messageDialogMock = new Mock<IMessageDialogService>();
            var addAccountDialogMock = new Mock<ICustomDialogService<AddAccountWindow>>();

            viewModel = new ClientsWindowViewModel(repositoryMock.Object, messageDialogMock.Object, addAccountDialogMock.Object);
        }

        [Test]
        public void ShouldContainClientsAfterCreation()
        {
            Assert.AreEqual(viewModel?.BankClients.Count, 2); 
        }

        [Test]
        public void ShouldHaveCommands()
        {
            Assert.IsNotNull(viewModel!.DeleteAccountCommand);
        }
    }
}
