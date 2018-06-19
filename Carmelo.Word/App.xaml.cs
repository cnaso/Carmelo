using Carmelo.Word.Core.IoC;
using System.Windows;

namespace Carmelo.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Startup to load IoC container for the application.
        /// </summary>
        /// <param name="e">Event argument object</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IocContainer.Configure();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
