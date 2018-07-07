using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace fasetto_word.Infrastructure.Animation
{
    /// <summary>
    /// Helper to animate framework elements in specfic ways.
    /// </summary>
    public static class FrameworkAnimationsHelper
    {
        /// <summary>
        /// Slides an element in from the right.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The time the animate take.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds=0.3f)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideFromRight(seconds,element.ActualHeight);
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
        /// Slides an element in from the Left.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The time the animate take.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideFromLeft(seconds, element.ActualHeight);
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
        /// Slides an element out from the left.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The time the animate take.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideToLeft(seconds, element.ActualHeight);
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
        /// Slides an element out from the right.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The time the animate take.</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideToRight(seconds, element.ActualHeight);
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