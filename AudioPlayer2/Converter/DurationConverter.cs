using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AudioPlayer2.Converter
{
    internal class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var duration = (Duration)value;
            if (value != null)
                if (duration.HasTimeSpan)
                    return ((Duration)value).TimeSpan.ToString(@"hh\:mm\:ss");
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
