using System;
using System.Windows.Input;

namespace Lab6.Base
{
    class RelayCommand : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> executionAction, Predicate<object> canBeExecuted = null)
        {
            _executionAction = executionAction;
            _canBeExecuted = canBeExecuted;
        }

        private readonly Action<object> _executionAction;
        private readonly Predicate<object> _canBeExecuted;

        public bool CanExecute(object parameter) => _canBeExecuted?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _executionAction.Invoke(parameter);
    }
}
