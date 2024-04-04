using System.Windows;
using TicTacToe;

namespace TicTacToe
{
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the MainWindow
            MainWindow gameWindow = new MainWindow();

            // Show the MainWindow
            gameWindow.Show();

            // Close the current WelcomeWindow
            this.Close();
        }
    }
}
