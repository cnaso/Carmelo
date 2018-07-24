using Carmelo.Word.Core.ViewModels;
using Carmelo.Word.Core.ViewModels.Base;
using System.Security;

namespace Carmelo.Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, ISecurePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The <see cref="SecureString"/> password inherited from the <see cref="ISecurePassword"/> interface.
        /// </summary>
        public SecureString Password => PasswordText.SecurePassword;
    }
}
