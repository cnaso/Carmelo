using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Carmelo.Word.AttachedProperties
{
    /// <summary>
    /// NoFrameHistory attached property for the <see cref="Frame"/> control.
    /// This is done to remove the navigation UI from coming up on the frame and keeps
    /// the pages navigated to history cleared so the keyboard shortcuts for the navigation
    /// UI are of no use.
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArg)
        {
            var frame = (sender as Frame);

            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
