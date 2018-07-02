

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


        #region Event Methods

        #region Public Event
        /// <summary>
        /// Fire when value changed
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion
        /// <summary>
        /// The method is called when attached property of this type is changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion



        #endregion

        #region Attached Property Definitions
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(TProperty), typeof(BaseAttachedProperty<TParent, TProperty>), new UIPropertyMetadata(OnValuePropertyChanged));
      
        /// <summary>
        /// callback event when <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">ui element</param>
        /// <param name="e">argument for the event</param>
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