using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace fasetto_word.Infrastructure.Animation
{
    public static class FrameworkElementAnimationHelper
    {
        /// <summary>
        /// The element Slide and fade in from right 
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The animate will take.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds=0.3f,bool keepMargin=true)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideFromRight(seconds,element.ActualHeight, keepMargin: keepMargin);
            //add fade in animation.
            sb.AddFadeIn(seconds);
            //start animating.
            sb.Begin(element);
            //make element visibile.
            element.Visibility = Visibility.Visible;
            //wait for this to finish.
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// The element Slide and fade in from left. 
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The animate will take.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from left animation.
            sb.AddSlideFromLeft(seconds, element.ActualHeight, keepMargin: keepMargin);
            //add fade in animation.
            sb.AddFadeIn(seconds);
            //start animating.
            sb.Begin(element);
            //make element visibile.
            element.Visibility = Visibility.Visible;
            //wait for this to finish.
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// The element Slide and fade out to left
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The animate will take.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideToLeft(seconds, element.ActualHeight, keepMargin: keepMargin);
            //add fade in animation.
            sb.AddFadeOut(seconds);
            //start animating.
            sb.Begin(element);
            //make element visibile.
            element.Visibility = Visibility.Visible;
            //wait for this to finish.
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// The element Slide and fade out to right
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The animate will take.</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideToRight(seconds, element.ActualHeight, keepMargin: keepMargin); 
            //add fade in animation.
            sb.AddFadeOut(seconds);
            //start animating.
            sb.Begin(element);
            //make element visibile.
            element.Visibility = Visibility.Visible;
            //wait for this to finish.
            await Task.Delay((int)seconds * 1000);
        }
    }
}