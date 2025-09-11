using MauiShopElectronics.Models.models;
using System.Globalization;

namespace MauiShopElectronics.Converts
{
    public class SelectListStringToProductConvert : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is List<Product> list)
            {
                return list.Select(x => $"{x.Brand.BrandName} {x.ProductName}").ToList();
            }
            else
                return new List<string>();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return new List<Product>();
        }
    }
}
