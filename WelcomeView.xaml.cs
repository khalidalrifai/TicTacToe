using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class WelcomeView : UserControl
    {
        // Define an event to signal when the start game button is clicked
        public event EventHandler StartGameClicked;

        public WelcomeView()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // Invoke the StartGameClicked event when the button is clicked
            StartGameClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
