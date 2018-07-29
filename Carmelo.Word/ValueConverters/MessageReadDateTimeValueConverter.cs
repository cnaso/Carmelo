using System;
using System.Globalization;

namespace Carmelo.Word
{
    /// <summary>
    /// Converts the message read date into user friendly format. If message is displayed and read on
    /// the current date only the time is displayed, if it was read at a previous date the date and time
    /// is displayed.
    /// </summary>
    class MessageReadDateTimeValueConverter : BaseValueConverter<MessageReadDateTimeValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            if (time == DateTimeOffset.MinValue)
            {
                return string.Empty;
            }

            if (time.Date == DateTimeOffset.UtcNow.Date)
            {
                return $"Read {time.ToLocalTime().ToString("t")}";
            }

            return $"Read {time.ToLocalTime().ToString("g")}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
