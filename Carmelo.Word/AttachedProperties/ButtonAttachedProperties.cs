using System.Windows;
using System.Windows.Controls;

namespace Carmelo.Word.AttachedProperties
{
    /// <summary>
    /// IsBusy attached property for the <see cref="Button"/> control.
    /// Used to remove placeholder text when the password length is greater than zero.
    /// </summary>
    public class IsBusyProperty : BaseAttachedProperty<IsBusyProperty, bool>
    {
    }
}
