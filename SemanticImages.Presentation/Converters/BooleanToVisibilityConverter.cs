using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SemanticImages.Presentation.ValueConversion
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is bool)
            {
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
