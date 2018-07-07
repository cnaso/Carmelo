using Carmelo.Word.Animations;
using System.Windows;

namespace Carmelo.Word.AttachedProperties
{
    /// <summary>
    /// Base class to start any animation when the boolean value is true on a <see cref="FrameworkElement"/>.
    /// </summary>
    /// <typeparam name="Parent">The control to start animation on.</typeparam>
    public abstract class AnimationBaseProperty<Parent> : BaseAttachedProperty<Parent, bool> where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        /// <summary>
        /// Flag indicating if the control has not been loaded. This allows for the animation
        /// to not be started on a controls first load.
        /// </summary>
        public bool IsFirstLoad { get; set; } = true;

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Animations on UI elements only. Declare variable if it is.
            if (!(sender is FrameworkElement element))
            {
                return;
            }

            //  Do not start animation if value is the same and IsFirstLoad is false.
            if (sender.GetValue(ValueProperty) == value && !IsFirstLoad)
            {
                return;
            }

            if (IsFirstLoad)
            {
                RoutedEventHandler onLoaded = null;

                // This fires the event once and then removes itself.
                onLoaded = (routedSender, e) =>
                {
                    element.Loaded -= onLoaded;

                    StartAnimation(element, (bool)value);

                    IsFirstLoad = false;
                };

                // Elements load event.
                element.Loaded += onLoaded; 
            }
            else
            {
                StartAnimation(element, (bool)value);
            }
        }

        protected virtual void StartAnimation(FrameworkElement element, bool value) { }
    }

    /// <summary>
    /// Animates a <see cref="FrameworkElement"/> by sliding it in from the left in it's parent container.
    /// </summary>
    public class SlideInFromLeftAnimationProperty : AnimationBaseProperty<SlideInFromLeftAnimationProperty>
    {
        protected override async void StartAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeInFromLeft(keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutFromRight(keepMargin: false);
            }
        }
    }
}
