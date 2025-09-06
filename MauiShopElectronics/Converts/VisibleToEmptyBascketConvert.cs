using Models.models;
using System.Globalization;

namespace MauiShopElectronics.Converts
{
	public class VisibleToEmptyBascketConvert : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			if (((List<ProductBascket>)value).Count > 0)
				return true;
			else
				return false;
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return new List<ProductBascket>();
		}
	}
}
