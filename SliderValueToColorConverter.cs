using System;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace BrandonChong_FinalTest
{
    public class SliderValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double sliderValue)
            {
                if (sliderValue < 40)
                    return Colors.Red;
                else if (sliderValue < 80)
                    return Colors.Black;
                else
                    return Colors.Green;
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
