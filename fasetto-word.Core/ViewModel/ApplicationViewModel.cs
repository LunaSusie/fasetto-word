using fasetto_word.Core.Infrastructure;
using fasetto_word.Core.Models;

namespace fasetto_word.Core.ViewModel
{
    public class ApplicationViewModel:BaseViewModel
    {

        #region pages

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion
    }
}