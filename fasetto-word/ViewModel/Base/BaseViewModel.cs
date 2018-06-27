using System.ComponentModel;
using System.Runtime.CompilerServices;
using fasetto_word.Annotations;

namespace fasetto_word.ViewModel.Base
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}