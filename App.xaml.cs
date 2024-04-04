using System.Windows;
using TicTacToe;

namespace TicTacToe
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create the main application window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
