using Carmelo.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Carmelo.Word.ViewModels
{
    /// <summary>
    /// View Model to handle the custom Window.
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        private Window window;

        public WindowViewModel(Window window)
        {
            this.window = window;
        }
    }
}
