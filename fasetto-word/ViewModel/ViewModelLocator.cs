using System.Net.Mime;
using fasetto_word.Core.IoC;
using fasetto_word.Core.ViewModel;

namespace fasetto_word.ViewModel
{
    /// <summary>
    /// Locater view models from the IoC for use bind in xaml files.
    /// </summary>
    public  class ViewModelLocator
    {
        public static ViewModelLocator Instance=new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => (ApplicationViewModel)IoC.Get<ApplicationViewModel>();
    }
}