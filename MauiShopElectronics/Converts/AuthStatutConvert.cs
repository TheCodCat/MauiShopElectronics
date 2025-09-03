using MauiShopElectronics.Models.models;
using System.Globalization;

namespace MauiShopElectronics.Converts
{
    public class AuthStatutConvert : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if ((User)value != null)
            {
                return false;
            }
            else
                return true;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
