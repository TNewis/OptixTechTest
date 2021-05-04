using OptixTechTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace OptixTechTest.Converters
{
    public class EnumSuitToSymbolConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			switch ((EnumSuit)value)
			{
				case EnumSuit.Hearts:
					return "♥";
				case EnumSuit.Diamonds:
					return "♦";
				case EnumSuit.Clubs:
					return "♣";
				case EnumSuit.Spades:
					return "♠";
				default:
					return "";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
