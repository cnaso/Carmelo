using System;
using System.Globalization;
using System.Windows.Media;

namespace Carmelo.Word
{
    /// <summary>
    /// Converts RGB string to a <see cref="SolidColorBrush"/>.
    /// </summary>
    class StringToBrushValueConverter : BaseValueConverter<StringToBrushValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
