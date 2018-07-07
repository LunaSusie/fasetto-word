using System.Collections.Generic;
using System.Windows;
using fasetto_word.Core.IoC;

namespace fasetto_word
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IoC.Setup();

            //Show main window.
            Current.MainWindow=new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
