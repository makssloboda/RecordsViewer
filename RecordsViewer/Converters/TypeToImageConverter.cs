using System;
using System.Globalization;
using System.Windows.Data;

namespace TestProject
{
    /// <summary>
    /// Converts type of node to a specific image
    /// </summary>
    public class NodeTypeToImageConverter : IValueConverter
    {
        /// <summary>
        /// Converter that does conversion
        /// </summary>
        public static NodeTypeToImageConverter Instance = new();

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
                NodeType.Folder => "Images/folder.png",
                NodeType.Record => "Images/record.png",
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
