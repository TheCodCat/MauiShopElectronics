using System.Globalization;

namespace MauiShopElectronics.Converts
{
	public class ArrayToImageConverts : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			if ((byte[])value == null) return null;

			var memory = new MemoryStream((byte[])value);
			return ImageSource.FromStream(() => memory);
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return new byte[0];
		}
	}
}
