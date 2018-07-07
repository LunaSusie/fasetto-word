
using System.Security;
using fasetto_word.Core.Models;
using fasetto_word.Core.ViewModel;
using fasetto_word.Infrastructure;
using fasetto_word.ViewModel;

namespace fasetto_word.Views.Pages
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPage : BasePage<LoginViewModel>,IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
