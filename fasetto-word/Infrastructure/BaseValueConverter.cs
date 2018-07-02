using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace fasetto_word.Infrastructure
{
    /// <summary>
    /// base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T>:MarkupExtension,IValueConverter where T:class,new()
    {
        #region Private Member
        /// <summary>
        /// static instance of this value converter
        /// </summary>
        private static T _converter = null;

        #endregion

        #region Markup Extension Methods

        /// <summary>
        /// Provider a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        #endregion

        #region Value Converter Methods
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
       

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    

        #endregion
    }
}
