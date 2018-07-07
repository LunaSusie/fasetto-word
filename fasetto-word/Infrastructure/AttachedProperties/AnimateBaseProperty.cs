using System.Windows;

namespace fasetto_word.Infrastructure.AttachedProperties
{
    public abstract class AnimateBaseProperty<TParent> : BaseAttachedProperty<TParent, bool>
        where TParent : BaseAttachedProperty<TParent, bool>, new()
    {
        /// <summary>
        /// A flag indicating if this is the first time this property has been loaded.
        /// </summary>
        public bool FirstLoaded { get; set; } = true;

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //get the element.
           if (!(sender is FrameworkElement element)) return;
           //the value is's changed and is't first loaded.
            if (sender.GetValue(ValueProperty) == value&&!FirstLoaded) return;

            if (FirstLoaded)
            {
                void Loaded(object s, RoutedEventArgs e)
                {
                    //unhook element's Loaded event.
                    element.Loaded -= Loaded;
                    //do animation
                    DoAnimation(element, (bool)value);
                    //no longer first load.
                    FirstLoaded = false;
                }
                //hook element's Loaded event.
                element.Loaded += Loaded;
            }
            else
            {
                //do animation
                DoAnimation(element, (bool)value);
            }

        }
        /// <summary>
        /// The animation method that fired when the value changed.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value){ }
    }
}