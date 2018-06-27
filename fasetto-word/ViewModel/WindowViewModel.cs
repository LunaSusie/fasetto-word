using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using CustomWindowAndStyles.ViewModel.Command;
using fasetto_word.ViewModel.Base;

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
        /// The margin around the window to allow for drop shadow
        /// </summary>
        private int _outerMarginSize = 10;
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windwoRadius = 10;

        #endregion

        #region Public Properties
        /// <summary>
        /// The size of resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        

        #region Main Window Inner

        /// <summary>
        ///  The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Minimized ? 0 : _windwoRadius;
            set => _windwoRadius = value;
        }
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindwoCornerRadius => new CornerRadius(WindowRadius);
        /// <summary>
        /// The height of the title bar/ caption of the window
        /// </summary>
        public int CaptionHeight { get; set; } = 42;
        public GridLength CaptionHeightGridLength => new GridLength(CaptionHeight+ResizeBorder); 
        #endregion

        #region Main Window Outer

        /// <summary>
        /// The margin around the window to allow for drop shadow
        /// </summary>
        public int OuterMargin
        {
            get => _window.WindowState == WindowState.Minimized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }
        /// <summary>
        ///   
        /// </summary>
        public Thickness OuterMarginThickness => new Thickness(OuterMargin);
        /// <summary>
        ///  taking into account the outter margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder+ OuterMargin);

        #endregion

        public Thickness InnerContentPadding=>new Thickness(ResizeBorder); 


        #endregion

        #region public command

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        #endregion
        #region Construct
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
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMargin));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindwoCornerRadius));
            };
            //create commands
            MinimizeCommand = new RelayCommand(()=>_window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand=new RelayCommand(()=>SystemCommands.ShowSystemMenu(_window, GetMousePosition()));
        }

        #endregion


        #region private helper 
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