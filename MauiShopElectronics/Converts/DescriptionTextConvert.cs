using System.Globalization;
using System.Text;

namespace MauiShopElectronics.Converts
{
	public class DescriptionTextConvert : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			StringBuilder stringBuilder = new StringBuilder(string.Empty);

			if(value is string text)
			{
				if(text.Length >= 20)
				{
					for (int i = 0; i < 20; i++)
					{
						stringBuilder.Append(text[i]);
					}

				}
				else
					stringBuilder.Append(text);

				stringBuilder.Append("...");
			}
			return stringBuilder.ToString();
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return string.Empty;
		}
	}
}
