using System.ComponentModel;
using Carmelo.Word.Extensions;

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
    }
}