﻿using System;
using System.Globalization;
using System.Windows;

namespace Carmelo.Word.ValueConverters
{
    class InverseBooleanToVisibilityValueConverter : BaseValueConverter<InverseBooleanToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Hidden : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
