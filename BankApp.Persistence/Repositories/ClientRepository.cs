using BankApp.Model.Entities;
using BankApp.Model.Enums;
using BankApp.Model.ValueObjects;
using BankApp.Persistence.Abstract;

namespace BankApp.Persistence.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private bool disposedValue;

        readonly IList<Client> _clients = new List<Client>();

        public ClientRepository()
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
            _clients.Add(new Client("Дмитрий", new Address("Россия", "Санкт-Петербург", "Подольская ул."))
            {
                SecondName = "Иванов",
                Accounts = new List<Account>
                {
                    new Account{ Balance = 30000, AccountType = AccountType.Deposit}
                },
            });
            _clients.Add(new Client("Юрий", new Address("Россия", "Санкт-Петербург", "Подольская ул."))
            {
                SecondName = "Юрьевский",
                Accounts = new List<Account>
                {
                    new Account{ Balance = 20000, AccountType = AccountType.NonDeposit}
                },
            });
        }

        public void Create(Client item)
        {
            _clients.Add(item);
        }

        public void Delete(int id)
        {
            var client = _clients.Where(e => e.Id == id).FirstOrDefault();
            if(client != null)
            {
                _clients.Remove(client);
            }
        }

        public Client Get(int id)
        {
            return _clients.Where(e => e.Id == id).First();
        }

        public IEnumerable<Client> GetList()
        {
            return _clients;
        }

        public void Save()
        {
            
        }

        public void Update(Client item)
        {
            var client = _clients.Where(e => e.Id == item.Id).FirstOrDefault();
            client = item;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
