using System.ComponentModel;
using Carmelo.Word.Extensions;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Carmelo.Base.ViewModels
{
    /// <summary>
    /// Base class for View Models that handles <see cref="PropertyChanged"/> events.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fires a <see cref="PropertyChanged"/> event with provided value safely using <see cref="PropertyChangedExtension"/> extension.
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged.SafeInvoke(this, name);
        }

        /// <summary>
        /// Runs a command if the <paramref name="updateFlag"/> is not true. Makes sure to reset the flag when complete.
        /// </summary>
        /// <param name="updateFlag">Flag indicating if the command is already running or not.</param>
        /// <param name="action">The action to run if the <paramref name="updateFlag"/> is false.</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updateFlag, Func<Task> action)
        {
            if (updateFlag.GetPropertyValue())
            {
                return;
            }

            updateFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                updateFlag.SetPropertyValue(false);
            }
        }
    }
}