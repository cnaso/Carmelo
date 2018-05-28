using Carmelo.Word.Animations;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Carmelo.Word.Pages
{
    /// <summary>
    /// Base page for all pages to inherit for animation functionality.
    /// </summary>
    public class BasePage : Page
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

        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += BasePage_Loaded;
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

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
