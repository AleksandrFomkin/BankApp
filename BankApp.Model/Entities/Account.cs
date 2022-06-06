using BankApp.Model.Enums;
using CSharpFunctionalExtensions;

namespace BankApp.Model.Entities
{
    /// <summary>
    /// Счет пользователя
    /// </summary>
    public class Account : Entity<int>
    {
        /// <summary>
        /// Номер счета пользователя
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Баланс пользователя
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Тип счета пользователя
        /// </summary>
        public AccountType AccountType { get; set; }

    }
}