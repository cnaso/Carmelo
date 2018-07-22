using Carmelo.Word.Animations;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Carmelo.Word.Core.ViewModels.Base;

namespace Carmelo.Word.Pages
{
    /// <summary>
    /// Base page for all pages to inherit for animation functionality.
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties
        /// <summary>
        /// Animation to play when page is loaded.
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Animation to play when page is unloaded.
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// Seconds the animation takes to complete.
        /// </summary>
        public float SlideSeconds { get; set; } = 0.5f;

        /// <summary>
        /// Flag to indicate if page should animate out on load. Used when moving page to another frame.
        /// </summary>
        public bool ShouldAnimateOut { get; set; }
        #endregion

        /// <summary>
        /// Default constructor sets the inheriting pages <see cref="Visibility"/> to Collapsed initally if the <see cref="PageAnimation"/> is None.
        /// </summary>
        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += BasePage_Loaded;
        }

        #region Public Methods
        /// <summary>
        /// Task loads the animation to display the page depending on the <see cref="PageAnimation"/> type.
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Task loads the animation to remove the page depending on the <see cref="PageAnimation"/> type.
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (PageUnLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSeconds);

                    break;
            }
        } 
        #endregion

        #region Private Methods
        /// <summary>
        /// Event that calls the <see cref="AnimateIn"/> task.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
            {
                await AnimateOut();
            }
            else
            {
                await AnimateIn();
            }
        }
        #endregion
    }

    /// <summary>
    /// Base page with added ViewModel support.
    /// </summary>
    public class BasePage<VM> : BasePage where VM : BaseViewModel, new()
    {
        /// <summary>
        /// View Model for the page. Updates the DataContext with the VM object.
        /// </summary>
        public VM ViewModel
        {
            get { return viewModel; }
            set
            {
                if (viewModel == value)
                {
                    return;
                }

                viewModel = value;
                DataContext = viewModel;
            }
        }

        /// <summary>
        /// Private variable for the VM object.
        /// </summary>
        private VM viewModel;

        /// <summary>
        /// Default constructor calls the inherited <see cref="BasePage"/> constructor then sets the <see cref="VM"/>.
        /// </summary>
        public BasePage() : base()
        {
            ViewModel = new VM();
        }
    }
}
