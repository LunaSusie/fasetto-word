using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using fasetto_word.Infrastructure.Animation;

namespace fasetto_word.Infrastructure.AttachedProperties
{
    /// <summary>
    /// A base animation to run any animation method when a boolean is set true and a reverse animation when set to false.
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public abstract class AnimationBaseProperty<TParent> : BaseAttachedProperty<TParent, bool>
        where TParent : BaseAttachedProperty<TParent,bool>, new()
    {
        #region Public Properties

        /// <summary>
        /// A flag indicating of this is the first time this property has been loaded.
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion
        /// <summary>
        ///
        /// 在元素第一次加载的时候，加载动画必须hook元素的onloaded事件，onloaded事件执行完毕之后必须unhook.
        /// 第一次加载值得时候，加载动画。
        /// 值改变的时候，加载动画。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //get the element
            if (!((sender) is FrameworkElement element)) return;
            //don't fire if the value doesn't change.
            if (sender.GetValue(ValueProperty)==value && !FirstLoad) return;

            //The value changed or the value is first loaded.
            if (FirstLoad)
            {
                //create a single self-unhookable event for the element Loaded event.
                RoutedEventHandler onLoaded = null;
                
                onLoaded=(s, e) =>
                {
                    //unhook
                    element.Loaded -= onLoaded;
                    //Do animation
                    DoAnimation(element,(bool)value);
                    //not first loaded.
                    FirstLoad = false;
                };
                //hook into the Loaded event of the element.
                element.Loaded += onLoaded;
            }
            else
            {
                //Do animation
                DoAnimation(element, (bool)value);
            }
        }

        /// <summary>
        /// Animation method that is fired when value is changed.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The new value.</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value){}
    }

    /// <summary>
    /// Animates a framework element sliding it in from the left on show,and sliding out to left to hide.
    /// 元素从左边进入，左边出去。
    /// </summary>
    public class AnimationSlideInFromLeftProperty:AnimationBaseProperty<AnimationSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate in 
                await element.SlideAndFadeInFromLeftAsync();
            else
                //Animate out
                await element.SlideAndFadeOutToLeftAsync();
        }   
    }
}