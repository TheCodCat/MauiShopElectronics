using System.Globalization;

namespace MauiShopElectronics.Converts
{
    public class DateOnlyTextConvert : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is DateOnly date)
            {
                return date.ToLongDateString();
            }
            else
                return DateOnly.FromDateTime(DateTime.Now);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new DateOnly();
        }
    }
}
