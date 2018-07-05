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
            //也就是说如果parameter有值，则value为true-显示，false-不显示，否则取反。
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