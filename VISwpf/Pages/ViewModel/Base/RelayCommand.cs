using System;
using System.Windows.Input;

namespace VISwpf.Pages.ViewModel.Base
{
    class RelayCommand : ICommand
    {
        #region Private Members
        private Action mAction;
        #endregion

        #region Public events
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Conctructor
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public RelayCommand()
        {
        }
        #endregion

        #region Command methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion
    }
}
