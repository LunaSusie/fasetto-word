using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace fasetto_word.Infrastructure.Animation
{
    public static class PageAnimationHelper
    {
        /// <summary>
        /// The page Slide and fade in from right 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideFromRight(seconds,page.WindowWidth);
            //add fade in animation.
            sb.AddFadeIn(seconds);
            //start animating.
            sb.Begin(page);
            //make page visibile.
            page.Visibility = Visibility.Visible;
            //wait for this to finish.
            await Task.Delay((int)seconds * 1000);
        }
        /// <summary>
        /// The page Slide and fade out to right
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            //create storyboard.
            var sb = new Storyboard();
            //add slide from right animation.
            sb.AddSlideToLeft(seconds, page.WindowWidth);
            //add fade in animation.
            sb.AddFadeOut(seconds);
            //start animating.
            sb.Begin(page);
            //make page visibile.
            page.Visibility = Visibility.Visible;
            //wait for this to finish.
            await Task.Delay((int)seconds * 1000);
        }
    }
}