using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestProject
{
    /// <summary>
    /// Converts type of node to controls visibility
    /// </summary>
    public class TypeToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converter instance to bind to
        /// </summary>
        public static TypeToVisibilityConverter Instance = new();

        /// <summary>
        /// Method that does conversion
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (NodeType)value switch
            {
                NodeType.Folder => Visibility.Visible,
                NodeType.Record => Visibility.Collapsed,
                _ => throw new ArgumentOutOfRangeException(nameof(value), $"Not expected node type: {(NodeType)value}"),
            };
        }

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
