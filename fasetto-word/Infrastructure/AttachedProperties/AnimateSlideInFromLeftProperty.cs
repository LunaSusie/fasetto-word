using System.Windows;
using fasetto_word.Infrastructure.Animation;

namespace fasetto_word.Infrastructure.AttachedProperties
{
    public class AnimateSlideInFromLeftProperty:AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            //第一次加载，没有持续时间。
            //不保留元素的边框=>不占用界面位置。
            if (value)
                //animate in 
                await element.SlideAndFadeInFromLeftAsync(FirstLoaded? 0 : 0.3f,false);
            else
                //animate out
                await element.SlideAndFadeOutToLeftAsync(FirstLoaded ? 0 : 0.3f,false);
        }
    }
}