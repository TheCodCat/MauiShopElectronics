using System.Globalization;

namespace MauiShopElectronics.Converts
{
    public class StatusRequestAuthConvert : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if ((bool)value)
                return "Успешная операция";
            else
                return "Ошибка операции";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
