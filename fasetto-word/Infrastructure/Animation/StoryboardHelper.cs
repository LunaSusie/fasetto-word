using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace fasetto_word.Infrastructure.Animation
{
    public static class StoryboardHelper
    {
        /// <summary>
        /// Add a slide from right animation on the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">the rate of deceleration</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f)
        {
            //create Margin animation from right
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);
        }
        /// <summary>
        /// Add a slide to left animation on the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">the rate of deceleration</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f)
        {
            //create Margin animation from right
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);
        }
        /// <summary>
        /// Add a fede in animation on the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            //create Margin animation from right
            var slideAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From =0,
                To =1
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));
            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);
        }

        /// <summary>
        /// Add a fede out animation on the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add animation</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            //create Margin animation from right
            var slideAnimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };
            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));
            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);
        }
    }
}