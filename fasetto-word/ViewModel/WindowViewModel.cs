using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using fasetto_word.Infrastructure;
using fasetto_word.Infrastructure.Command;
using fasetto_word.Models;

namespace fasetto_word.ViewModel
{
    /// <summary>
    /// ViewModel for custom windows
    /// </summary>
    public class WindowViewModel:BaseViewModel
    {

        #region Private Member

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private readonly Window _window;
        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;
        /// <summary>
        /// The margin around the window to allow for drop shadow
        /// </summary>
        private int _outerMarginSize = 10;
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windwoRadius = 10;
        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// 是否需要边框，最小化和停靠锁定的时候不需要
        /// </summary>
        private bool Borderless => (_window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked);

        /// <summary>
        /// The size of resize border around the window
        /// 重置窗口大小的时候边框
        /// </summary>
        private int ResizeBorder => Borderless ? 0: 6;
        /// <summary>
        ///  The radius of the edges of the window
        /// 圆角-最小化的时候为0
        /// </summary>
        private int WindowRadius
        {
            get => _window.WindowState == WindowState.Minimized ? 0 : _windwoRadius;
            set => _windwoRadius = value;
        }
        /// <summary>
        /// The margin around the window to allow for drop shadow
        /// 窗口最外边距
        /// </summary>
        private int OuterMargin
        {
            get => (_window.WindowState == WindowState.Maximized || _dockPosition == WindowDockPosition.Undocked) ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }
    
        #endregion


        #region Public Properties

        /// <summary>
        /// The smallest width the window 
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height the window 
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// The margin around the window to allow for drop shadow
        /// 窗口最外边距
        /// </summary>
        public Thickness OuterMarginThickness => new Thickness(OuterMargin);
        /// <summary>
        ///  taking into account the outter margin
        /// 重置窗口最外边-边距
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMargin);
        /// <summary>
        /// 圆角
        /// </summary>
        public Thickness WindwoCornerRadius =>new Thickness(WindowRadius);

        /// <summary>
        /// The Inner Content padding.
        /// 内容边距
        /// </summary>
        public Thickness InnerContentPadding => new Thickness(0);
        /// <summary>
        /// The height of the title bar/ caption of the window.
        /// 标题高度
        /// </summary>
        public int CaptionHeight { get; set; } = 42;
        public GridLength CaptionHeightGridLength => new GridLength(CaptionHeight + ResizeBorder);

        #region pages

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #endregion


        #region public command

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// default construct
        /// </summary>
        public WindowViewModel(Window window)
        {
            _window = window;
            //listen out for window resize
            _window.StateChanged += (sender, e) =>
            {
                //fire off events for all properties that are affected by a resize
                WindowResized();
            };

            //  // Fix window resize issue ,Listen out for dock changes
            var resizer = new WindowResizer(_window);
            resizer.WindowDockChanged += (dock) =>
            {
                _dockPosition = dock;
                WindowResized();
            };

            //create commands
            MinimizeCommand = new RelayCommand(()=>_window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand=new RelayCommand(()=>SystemCommands.ShowSystemMenu(_window, GetMousePosition())); 
        }

        #endregion

        #region private helper 

        /// <summary>
        /// If the window resizes to a special position (docked or maximized)
        /// this will update all required property change events to set the borders and radius values
        /// </summary>
        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(OuterMarginThickness));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(WindwoCornerRadius));
            OnPropertyChanged(nameof(InnerContentPadding));
            OnPropertyChanged(nameof(CaptionHeightGridLength));            
        }


        //use winapi to get cursor position or use Mouse class

        //private Point GetMousePosition()
        //{
        //    var pos = Mouse.GetPosition(_window);
        //    return new Point(pos.X+_window.Left,pos.Y+_window.Top);
        //}

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point p);
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        }

        private static Point GetMousePosition()
        {
            Win32Point w32Mouse=new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        
        #endregion
    }
}