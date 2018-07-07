using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Carmelo.Word.Animations
{
    /// <summary>
    /// Helper class allows <see cref="FrameworkElement"/> UI objects to be animated in specific ways.
    /// </summary>
    public static class FrameElementAnimationHelpers
    {
        /// <summary>
        /// Create the animation <see cref="Storyboard"/> that slides a <see cref="FrameworkElement"/> in from the right.
        /// </summary>
        /// <param name="element">The element to be animated.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var storyboard = new Storyboard();

            storyboard.AddSlideOutFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            storyboard.AddFade(seconds, PageAnimation.FadeOut);

            storyboard.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Create the animation <see cref="Storyboard"/> that slides a <see cref="FrameworkElement"/> in from the left.
        /// </summary>
        /// <param name="element">The element to be animated.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            var storyboard = new Storyboard();

            storyboard.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            storyboard.AddFade(seconds, PageAnimation.FadeIn);

            storyboard.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
    }
}
