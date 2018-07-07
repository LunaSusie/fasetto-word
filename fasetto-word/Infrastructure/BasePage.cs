using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using fasetto_word.Core.Infrastructure;
using fasetto_word.Infrastructure.Animation;

namespace fasetto_word.Infrastructure
{
    public class BasePage<TViewModl> :Page where TViewModl:BaseViewModel,new()
    {

        #region Private Member

        private TViewModl _viewModel;

        #endregion

        #region Properties

        /// <summary>
        /// The animation the play when the element is first load.
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; }= PageAnimation.SlideAndFadeInFromRight;
        /// <summary>
        /// The animation the play when element unload.
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; }= PageAnimation.SlideAndFadeOutToLeft;
        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSecond { get; set; } = 0.9f;

        public TViewModl ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value) return;
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        #endregion

        #region Constructor

        public BasePage()
        {
            //if we are animation,hide to begin with.
            if (PageLoadAnimation == PageAnimation.None) Visibility = Visibility.Collapsed;

            Loaded += BasePage_Load;
            DataContext=new TViewModl();
        }

        #endregion

        #region Animation load and unload 

        /// <summary>
        /// First this element is load. preform any required animation.
        /// </summary>
        /// <returns></returns>
        private async void BasePage_Load(object sender, RoutedEventArgs e)
        {
            await AnimationIn();
        }
        #endregion
        /// <summary>
        /// animation this element in.
        /// </summary>
        /// <returns></returns>
        public async Task AnimationIn()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(SlideSecond);
                    break;
            }
            return;
        }
        /// <summary>
        /// Animation this element out.
        /// </summary>
        /// <returns></returns>
        public async Task AnimationOut()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeftAsync(SlideSecond);
                    break;
            }
            return;
        }

    }
}