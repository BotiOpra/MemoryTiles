﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Xceed.Wpf.AvalonDock.Converters;

namespace MemoryTilesGame.Utilities
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && targetType == typeof(Visibility))
            {
                if ((bool)value)
                {
                    return Visibility.Visible;
                }

                if (parameter != null && parameter is Visibility)
                {
                    return parameter;
                }

                return Visibility.Hidden;
            }

            if (value == null)
            {
                if (parameter != null && parameter is Visibility)
                {
                    return parameter;
                }

                return Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility && targetType == typeof(bool))
            {
                if ((Visibility)value == Visibility.Visible)
                {
                    return true;
                }

                return false;
            }

            throw new ArgumentException("Invalid argument/return type. Expected argument: Visibility and return type: bool");
        }
    }
}
