using System.Windows;
using fasetto_word.Core.ViewModel;
using fasetto_word.ViewModel;

namespace fasetto_word
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
        }
    }
}
