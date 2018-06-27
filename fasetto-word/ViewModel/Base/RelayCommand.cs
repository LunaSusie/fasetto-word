using System;
using System.Windows.Input;

namespace CustomWindowAndStyles.ViewModel.Command
{
    /// <summary>
    /// a base command that runs a action.
    /// </summary>
    public class RelayCommand : ICommand
    {

        #region private members
        /// <summary>
        /// the action to run.
        /// </summary>
        private readonly Action _action;

        #endregion

        #region construct 
        public RelayCommand(Action action)
        {
            _action = action;
        }
        #endregion

        #region public event

        /// <summary>
        /// The event that's fired when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        #endregion

        /// <summary>
        /// a relay command alway can execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Execute the command action.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action.Invoke();
        }


    }
}