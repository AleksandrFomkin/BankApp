using BankApp.Model.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace BankApp.UI.Converters
{

    [ValueConversion(typeof(AccountType), typeof(string))]
    public class AccountTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is AccountType type)
            {
                switch (type)
                {
                    case AccountType.Deposit:
                        return "Депозитный";
                    case AccountType.NonDeposit:
                        return "Недепозитный";
                    default:
                        break;
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new Exception("Can't convert back");
        }
    }
}
