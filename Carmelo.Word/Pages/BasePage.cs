using Carmelo.Word.Animations;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Carmelo.Base.ViewModels;

namespace Carmelo.Word.Pages
{
    /// <summary>
    /// Base page for all pages to inherit for animation functionality.
    /// </summary>
    public class BasePage<VM> : Page where VM : BaseViewModel, new()
    {
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
        public float SlideSeconds { get; set; } = 1.0f;

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
        /// Default constructor sets the inheriting pages <see cref="Visibility"/> to Collapsed initally if the <see cref="PageAnimation"/> is None.
        /// Also sets the inheriting pages Loaded event and creates a new <see cref="VM"/>.
        /// </summary>
        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += BasePage_Loaded;
            ViewModel = new VM();
        }

        /// <summary>
        /// Event that calls the <see cref="AnimateIn"/> task.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        /// <summary>
        /// Task loads the animation to display the page depending on the <see cref="PageAnimation"/> type.
        /// </summary>
        /// <returns></returns>
        private async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await PageAnimationHelpers.SlideAndFadeInFromRight(this, SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Task loads the animation to remove the page depending on the <see cref="PageAnimation"/> type.
        /// </summary>
        /// <returns></returns>
        private async Task AnimateOut()
        {
            if (PageUnLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await PageAnimationHelpers.SlideAndFadeOutToLeft(this, SlideSeconds);

                    break;
            }
        }
    }
}
