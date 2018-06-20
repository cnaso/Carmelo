using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Carmelo.Word.Animations
{
    /// <summary>
    /// Helper class allows pages to be animated in specific ways.
    /// </summary>
    public static class PageAnimationHelpers
    {
        /// <summary>
        /// Create the animation <see cref="Storyboard"/> that slides in from the right.
        /// </summary>
        /// <param name="page">The page to be animated.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            var storyboard = new Storyboard();

            storyboard.AddSlideFromRight(seconds, page.WindowWidth);

            storyboard.AddFade(seconds, PageAnimation.FadeIn);

            storyboard.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Create the animation <see cref="Storyboard"/> that slides out to the left.
        /// </summary>
        /// <param name="page">The page to be animated.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            var storyboard = new Storyboard();

            storyboard.AddSlideFromLeft(seconds, page.WindowWidth);

            storyboard.AddFade(seconds, PageAnimation.FadeOut);

            storyboard.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
    }
}
