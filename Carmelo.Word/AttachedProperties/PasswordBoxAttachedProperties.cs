using System.Windows;
using System.Windows.Controls;

namespace Carmelo.Word
{
    /// <summary>
    /// MonitorPassword attached property for the <see cref="PasswordBox"/> control.
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArg)
        {
            var passwordBox = (sender as PasswordBox);

            if (passwordBox == null)
            {
                return;
            }

            // Remove previous event.
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)eventArg.NewValue)
            {
                HasTextProperty.SetValue(passwordBox);

                // Add event listener to monitor for changes.
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Fired when the <see cref="PasswordBox"/> password value changes.
        /// </summary>
        /// <param name="sender">Element to set the property</param>
        /// <param name="e"></param>
        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// HasText attached property for the <see cref="PasswordBox"/> control.
    /// Used to remove placeholder text when the password length is greater than zero.
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Sets the HasText property based on the <see cref="PasswordBox"/> caller has any text.
        /// </summary>
        /// <param name="sender">Element to set the property.</param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
