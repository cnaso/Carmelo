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
    /// View Model to handle the <see cref="LoginPage"/>.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public bool LoginInProgress { get; set; }

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
            RegisterCommand = new RelayCommand(async () => await Register());
        }

        /// <summary>
        /// Logs the user into the application.
        /// </summary>
        /// <param name="parameter"><see cref="SecureString"/> passed in from the view for the users password.</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await RunCommand(() => LoginInProgress, async () =>
            {
                await Task.Delay(1000);
                //var hash = (parameter as ISecurePassword).Password.Hash();

                IocContainer.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
            });
        }

        /// <summary>
        /// Takes user to the <see cref="RegisterPage"/>.
        /// </summary>
        /// <param name="parameter">Object containing register information.</param>
        /// <returns></returns>
        public async Task Register()
        {
            IocContainer.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);
        }
    }
}
