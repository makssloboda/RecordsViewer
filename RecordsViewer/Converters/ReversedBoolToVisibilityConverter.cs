using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestProject
{
    /// <summary>
    /// Converts bool to visibility (reversed)
    /// </summary>
    public class ReversedBoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converter instance to bind to
        /// </summary>
        public static ReversedBoolToVisibilityConverter Instance = new();

        /// <summary>
        /// Method that does conversion
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            !(bool)value ? Visibility.Visible : Visibility.Collapsed;

        /// <summary>
        /// Reverse conversion isn't needed
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
