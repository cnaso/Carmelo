﻿using System.Windows.Input;
using System.Threading.Tasks;
using Carmelo.Word.Core.ViewModels.Base;
using Carmelo.Word.Core.Commands;
using Carmelo.Word.Core.Extensions;
using Carmelo.Word.Core.IoC;

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
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await Register(parameter));
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
                await Task.Delay(5000);
                var hash = (parameter as ISecurePassword).Password.Hash();
            });
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="parameter">Object containing register information.</param>
        /// <returns></returns>
        public async Task Register(object parameter)
        {
            IocContainer.Get<ApplicationViewModel>().SideListVisible ^= true;
        }
    }
}
