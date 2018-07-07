using System;
using System.Globalization;
using fasetto_word.Core.Models;
using fasetto_word.Views.Pages;

namespace fasetto_word.Infrastructure.ValueConverters
{
    public class ApplicationPageValueConverter:BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login: return new LoginPage();
                case ApplicationPage.Chat:return new ChatPage();
                case ApplicationPage.Register: return new RegisterPage();
                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}