using System;
using System.Globalization;
using System.Windows;

namespace Carmelo.Word
{
    /// <summary>
    /// Converts a boolean value to the selected color for the chat message bubbles.
    /// </summary>
    class MessageSentByColorValueConveter : BaseValueConverter<MessageSentByColorValueConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (bool)value ? "Color.FadedLightBlueBrush" : "Color.WhiteBrush";

            return Application.Current.FindResource(color);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
