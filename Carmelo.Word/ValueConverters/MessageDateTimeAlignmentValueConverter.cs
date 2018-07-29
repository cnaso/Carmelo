using System;
using System.Globalization;
using System.Windows;

namespace Carmelo.Word
{
    /// <summary>
    /// Converts a boolean value to align the messages in the chat page.
    /// </summary>
    class MessageDateTimeAlignmentValueConverter : BaseValueConverter<MessageDateTimeAlignmentValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
