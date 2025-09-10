using Models;
using System.Globalization;

namespace MauiShopElectronics.Converts
{
	public class MethodToReceiptConvert : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			if(value is MethodOfReceipt metod)
			{
				return metod switch 
				{
					MethodOfReceipt.UponReceipt => "Оплата при получении",
					MethodOfReceipt.PaymentImmediately => "Оплата сразу",
					_=> "Другой метод"
				};

			}
			else
				return "Другой метод";
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return MethodOfReceipt.UponReceipt;
		}
	}
}
