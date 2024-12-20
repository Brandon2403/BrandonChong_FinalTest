using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace BrandonChong_FinalTest
{
    public class SliderValueToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double sliderValue)
            {
                if (sliderValue < 40)
                    return "Failed";
                else if (sliderValue < 80)
                    return "Passed";
                else
                    return "Excellent";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
