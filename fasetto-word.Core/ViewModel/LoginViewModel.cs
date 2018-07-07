using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using fasetto_word.Core.Infrastructure;
using fasetto_word.Core.Infrastructure.Command;
using fasetto_word.Core.Infrastructure.Helper.Secure;
using fasetto_word.Core.Models;
using IHavePassword = fasetto_word.Core.Models.IHavePassword;

namespace fasetto_word.Core.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member

        #endregion

        #region Public Properties

        public string Email { get; set; }
        public SecureString Password { get; set; }

        public bool LoginIsRuning { get; set; }

        #endregion

        #region Command

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }
        

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));

            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
    }

      

        #endregion

        /// <summary>
        /// user login
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private async Task LoginAsync(object parameter)
        {

            await RunCommand(() => LoginIsRuning, async () =>
            {
                await Task.Delay(5000);
                var email = Email;

                //IMPORTANT: Never store unsecure password in variable like this
                var pass = (parameter as IHavePassword)?.SecurePassword.UnSecure();
            });

        }
        private async Task RegisterAsync()
        {

            IoC.IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            return;

            //IoC.IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;


            await Task.Delay(1000);
        }
    }
}