using Carmelo.Word.Core.DataModels;
using Carmelo.Word.Core.ViewModels.Base;

namespace Carmelo.Word.Core.ViewModels
{
    /// <summary>
    /// Application view state.
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// Current page to be displayed in the application.
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// Side List to be visible or not.
        /// </summary>
        public bool SideListVisible { get; set; } = false;

        /// <summary>
        /// Navigate to the specified page.
        /// </summary>
        /// <param name="page"></param>
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            SideListVisible = page == ApplicationPage.Chat;
        }
    }
}
