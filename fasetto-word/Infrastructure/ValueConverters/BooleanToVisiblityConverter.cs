using System;
using System.Globalization;
using System.Windows;

namespace fasetto_word.Infrastructure.ValueConverters
{
    public class BooleanToVisiblityConverter:BaseValueConverter<BooleanToVisiblityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //the paramenter is come from converterParmeter ,set in xmal
            if (parameter==null)
            return value != null && (bool)value ? Visibility.Hidden : Visibility.Visible;
            else
            return value != null && (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}