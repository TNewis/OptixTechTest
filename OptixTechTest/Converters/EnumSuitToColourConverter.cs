using OptixTechTest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace OptixTechTest.Converters
{
    public class EnumSuitToColourConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((EnumSuit)value)
			{
				case EnumSuit.Hearts:
				case EnumSuit.Diamonds:
					return "#FF0000";
				case EnumSuit.Clubs:
				case EnumSuit.Spades:
					return "#000000";
				default:
					return "#00FF00";

			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
