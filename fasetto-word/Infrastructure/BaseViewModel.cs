using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using fasetto_word.Annotations;
using fasetto_word.Infrastructure.Expression;

namespace fasetto_word.Infrastructure
{
    public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Command Helper
        /// <summary>
        /// runs a command if the undating the flag is not set
        /// if the flag is true , the action is not run.
        /// if the flag is false,the action is run.
        /// </summary>
        /// <param name="updataFlag"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task RunCommand(Expression<Func<bool>> updataFlag, Func<Task> action)
        {
            if (updataFlag.GetPropertyValue())
                return;
            updataFlag.SetPropertyValue(true);
            try
            {
                await action();
            }
            finally
            {
                updataFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}