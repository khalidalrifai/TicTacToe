using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class WelcomeView : UserControl
    {
        public event EventHandler StartGameClicked;

        public WelcomeView()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            StartGameClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
