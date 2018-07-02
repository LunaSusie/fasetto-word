using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using fasetto_word.Infrastructure;
using fasetto_word.Infrastructure.Command;
using fasetto_word.Infrastructure.Secure;

namespace fasetto_word.ViewModel
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

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }


        #endregion

        /// <summary>
        /// user login
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private async Task Login(object parameter)
        {

            await RunCommand(() => LoginIsRuning, async () =>
            {
                await Task.Delay(5000);
                var email = Email;

                //IMPORTANT: Never store unsecure password in variable like this
                var pass = (parameter as IHavePassword)?.SecurePassword.UnSecure();
            });

        }
    }
}