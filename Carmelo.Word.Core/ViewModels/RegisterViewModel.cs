using System.Windows.Input;
using System.Threading.Tasks;
using Carmelo.Word.Core.ViewModels.Base;
using Carmelo.Word.Core.Commands;
using Carmelo.Word.Core.Extensions;
using Carmelo.Word.Core.IoC;
using Carmelo.Word.Core.DataModels;

namespace Carmelo.Word.Core.ViewModels
{
    /// <summary>
    /// View Model to handle the <see cref="RegisterPage"/>.
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public bool RegisterInProgress { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            LoginCommand = new RelayCommand(async () => await Login());
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await Register(parameter));
        }

        /// <summary>
        /// Registers the user account.
        /// </summary>
        /// <param name="parameter"><see cref="SecureString"/> passed in from the view for the users password.</param>
        /// <returns></returns>
        public async Task Register(object parameter)
        {
            await RunCommand(() => RegisterInProgress, async () =>
            {
                await Task.Delay(5000);
                var hash = (parameter as ISecurePassword).Password.Hash();
            });
        }

        /// <summary>
        /// Takes user to the <see cref="LoginPage"/>.
        /// </summary>
        /// <param name="parameter">Object containing register information.</param>
        /// <returns></returns>
        public async Task Login()
        {
            IocContainer.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
        }
    }
}
