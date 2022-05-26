using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace ContactManager
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Genders g = (Genders)value;

            return g == Genders.Male
                ? "pack://application:,,,/Resources/man.png"
                : "pack://application:,,,/Resources/woman.jpg";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Collapsed.ToString();
            }
            else
            {
                return Visibility.Visible.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
