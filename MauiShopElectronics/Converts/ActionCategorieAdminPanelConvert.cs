using System.Globalization;

namespace MauiShopElectronics.Converts
{
    public class ActionCategorieAdminPanelConvert : IValueConverter
    {
        public int ActionNumber { get; set; }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int indexPage)
            {
                if (indexPage == ActionNumber)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
