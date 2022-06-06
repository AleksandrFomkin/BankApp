using BankApp.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace BankApp.Model.Entities
{
    /// <summary>
    /// Пользователь банковской системы
    /// </summary>
    public class Client : Entity<int>
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string? SecondName { get; set; }

        /// <summary>
        /// Список пользовательских счетов
        /// </summary>
        public IList<Account> Accounts { get; set; }

        /// <summary>
        /// Адрес проживания пользователя
        /// </summary>
        public Address Address { get; set; }

        public Client(string name, Address address)
        {
            Name = name;
            Address = address;
            Accounts = new List<Account>();
        }
    }
}