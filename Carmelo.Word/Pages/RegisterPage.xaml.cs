using Carmelo.Word.Core.ViewModels;
using Carmelo.Word.Core.ViewModels.Base;
using System.Security;

namespace Carmelo.Word.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, ISecurePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The <see cref="SecureString"/> password inherited from the <see cref="ISecurePassword"/> interface.
        /// </summary>
        public SecureString Password => PasswordText.SecurePassword;
    }
}
