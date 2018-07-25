using System;
using System.Windows.Input;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// Class handles firing parameterized commands implemented from the <see cref="ICommand"/> interface.
    /// </summary>
    public class RelayParameterizedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> action;

        public RelayParameterizedCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
