using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Carmelo.Word
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>.
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Add a slide from right animation to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">Storyboard to add the animation to.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <param name="offset">Distance the page is to the right from center.</param>
        /// <param name="decelerationRatio">Deceleration of the animation.</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Add a slide to left animation to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">Storyboard to add the animation to.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <param name="offset">Distance the page is to the right from center.</param>
        /// <param name="decelerationRatio">Deceleration of the animation.</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to right animation to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">Storyboard to add the animation to.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <param name="offset">Distance the page is to the right from center.</param>
        /// <param name="decelerationRatio">Deceleration of the animation.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Add a slide to left animation to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">Storyboard to add the animation to.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// <param name="offset">Distance the page is to the left from center.</param>
        /// <param name="decelerationRatio">Deceleration of the animation.</param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Add a fade animation to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">Storyboard to add the animation to.</param>
        /// <param name="seconds">Seconds the animation takes to complete.</param>
        /// /// <param name="animationType">Type of fade animation in or out.</param>
        public static void AddFade(this Storyboard storyboard, float seconds, PageAnimation fade)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = fade == PageAnimation.FadeIn ? 0 : 1,
                To = fade == PageAnimation.FadeIn ? 1 : 0
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }
    }
}
