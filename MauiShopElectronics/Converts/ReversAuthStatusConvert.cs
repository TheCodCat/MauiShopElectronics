using MauiShopElectronics.Models.models;
using System.Globalization;

namespace MauiShopElectronics.Converts
{
    public class ReversAuthStatusConvert : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if ((User)value != null)
            {
                return true;
            }
            else
                return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
