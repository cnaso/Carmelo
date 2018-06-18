using System;
using System.Windows.Input;

namespace Carmelo.Word.Core.Commands
{
    /// <summary>
    /// Class handles firing commands implemented from the <see cref="ICommand"/> interface.
    /// </summary>
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
