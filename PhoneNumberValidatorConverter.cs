using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

namespace BrandonChong_FinalTest
{
    public class PhoneNumberValidatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string phoneNumber = value as string;
            return !string.IsNullOrEmpty(phoneNumber) && Regex.IsMatch(phoneNumber, @"^\d+$");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
