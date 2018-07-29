using System;
using System.Globalization;

namespace Carmelo.Word
{
    /// <summary>
    /// Converts the message sent date into user friendly format. If message is displayed and sent on
    /// the current date only the time is displayed, if it was sent at a previous date the date and time
    /// is displayed.
    /// </summary>
    class MessageSentDateTimeValueConverter : BaseValueConverter<MessageSentDateTimeValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            if (time.Date == DateTimeOffset.UtcNow.Date)
            {
                return time.ToLocalTime().ToString("t");
            }

            return time.ToLocalTime().ToString("g");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
