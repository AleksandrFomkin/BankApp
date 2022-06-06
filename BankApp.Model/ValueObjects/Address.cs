using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Model.ValueObjects
{
    /// <summary>
    /// Адрес клиента
    /// </summary>
    /// <remarks>
    /// Представляет собой объект-значение для вдреса клиента
    /// сравнение идет по Стране и Городу. Улица не важна.
    /// </remarks>
    public class Address : ValueObject
    {
        public Address(string country, string city)
        {
            Country = country;
            City = city;
        }

        public Address(string country, string city, string? street)
        {
            Country = country;
            City = city;
            Street = street;
        }

        /// <summary>
        /// Страна проживания
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string? Street { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country ?? throw new NullReferenceException(nameof(Country));
            yield return City ?? throw new NullReferenceException(nameof(City));
        }
    }
}
