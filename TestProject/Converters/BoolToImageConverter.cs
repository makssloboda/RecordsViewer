using System;
using System.Globalization;
using System.Windows.Data;

namespace TestProject
{
    /// <summary>
    /// Converts bool to image
    /// </summary>
    public class BoolToImageConverter : IValueConverter
    {
        /// <summary>
        /// Converter instance to bind to
        /// </summary>
        public static BoolToImageConverter Instance = new();

        /// <summary>
        /// Method that does conversion
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (bool)value ? "Images\\done.png" : "Images\\edit.png";

        /// <summary>
        /// Reverse conversion isn't needed
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
