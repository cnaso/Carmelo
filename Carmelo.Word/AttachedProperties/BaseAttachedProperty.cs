using System;
using System.Windows;

namespace Carmelo.Word
{
    /// <summary>
    /// Base class for attached properties.
    /// </summary>
    /// <typeparam name="Parent">Parent class of the attached property.</typeparam>
    /// <typeparam name="Property">Type of the attached property.</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property> where Parent : new()
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the parent class.
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        /// <summary>
        /// Attach property for the provided <see cref="Parent"/> class.
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value", 
            typeof(Property), 
            typeof(BaseAttachedProperty<Parent, Property>), 
            new PropertyMetadata(default(Property), 
                new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValuePropertyUpdated)));

        /// <summary>
        /// Get attached property.
        /// </summary>
        /// <param name="dependency">Element to get the property from.</param>
        /// <returns>Property value.</returns>
        public static Property GetValue(DependencyObject dependency) => (Property)dependency.GetValue(ValueProperty);

        /// <summary>
        /// Set attached property.
        /// </summary>
        /// <param name="dependency">Element to set the property.</param>
        /// <param name="value">Value to set the property to.</param>
        public static void SetValue(DependencyObject dependency, Property value) => dependency.SetValue(ValueProperty, value);

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when the property changes.
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged;

        /// <summary>
        /// Fired when the property is updated, even if the value is not changed.
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated;

        #endregion

        /// <summary>
        /// Called when any attached property of this type is changed.
        /// </summary>
        /// <param name="sender">UI element that has it's property changed.</param>
        /// <param name="eventArg">Arguments for the event.</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArg) { }

        /// <summary>
        /// Called when any attached property of this type is updated.
        /// </summary>
        /// <param name="sender">UI element that has it's property updated.</param>
        /// <param name="value">Value passed in for the event.</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }

        /// <summary>
        /// Callback event when the <see cref="ValueProperty"/> is changed.
        /// </summary>
        /// <param name="sender">UI element that has it's property changed.</param>
        /// <param name="eventArg">Arguments for the event.</param>
        private static void OnValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArg)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(sender, eventArg);

            if ((Instance as BaseAttachedProperty<Parent, Property>).ValueChanged == null)
            {
                return;
            }

            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(sender, eventArg);
        }

        /// <summary>
        /// Callback event when the <see cref="ValueProperty"/> is updated, even if value is not changed.
        /// </summary>
        /// <param name="sender">UI element that has it's property updated.</param>
        /// <param name="value">Value passed in for the event.</param>
        private static object OnValuePropertyUpdated(DependencyObject sender, object value)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(sender, value);

            if ((Instance as BaseAttachedProperty<Parent, Property>).ValueUpdated == null)
            {
                return value;
            }

            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(sender, value);

            return value;
        }
    }
}
