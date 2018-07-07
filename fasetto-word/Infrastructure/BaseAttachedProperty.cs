

using System;
using System.Windows;

namespace fasetto_word.Infrastructure
{
    /// <summary>
    /// a base attached property
    /// </summary>
    /// <typeparam name="TParent">a parent call to be the attached property</typeparam>
    /// <typeparam name="TProperty">the type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<TParent,TProperty> 
        where TParent: BaseAttachedProperty<TParent,TProperty>,new()
    {
        #region Public Properties

        public static TParent Instance { get; private set; }= new TParent();

        #endregion

        #region Public Method
        /// <summary>
        /// The method is called when attached property of this type is changed.
        /// </summary>
        /// <param name="sender">The UI Element.</param>
        /// <param name="e">The argument for the event.</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {}

        /// <summary>
        /// The method is called when attached property of this type is changed,even vuale is the same.
        /// </summary>
        /// <param name="sender">The UI Element.</param>
        /// <param name="value">The new value.</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value){}
        #endregion


        #region Public Event
        /// <summary>
        /// Fire when value changed
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Attached Property Definitions
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", 
            typeof(TProperty), 
            typeof(BaseAttachedProperty<TParent, TProperty>), 
            new UIPropertyMetadata(default(TProperty),
                new PropertyChangedCallback(OnValuePropertyChanged),
                new CoerceValueCallback(OnValuePropertyUpdated)
                )
            );

        /// <summary>
        /// Callback event when <see cref="ValueProperty"/> is update.
        /// </summary>
        /// <param name="d">The UI Element.</param>
        /// <param name="value">The new value.</param>
        /// <returns></returns>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            Instance.OnValueUpdated(d, value);

            Instance.ValueUpdated(d, value);

            return value;
        }

        /// <summary>
        /// callback event when <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI Element</param>
        /// <param name="e">The argument for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d,e);

            Instance.ValueChanged(d, e);
        }

        public static TProperty GetValue(DependencyObject d) => (TProperty) d.GetValue(ValueProperty);
        public static void SetValue(DependencyObject d,TProperty value) => d.SetValue(ValueProperty,value);

        #endregion
    }
}