using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class WelcomeView : UserControl
    {
        public class StartGameEventArgs : EventArgs
        {
            public bool IsVsComputer { get; set; }
            public string Difficulty { get; set; }
        }

        public event EventHandler<StartGameEventArgs> StartGameClicked;

        public WelcomeView()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            var args = new StartGameEventArgs
            {
                IsVsComputer = (bool)(FindName("Play Against the Computer") as RadioButton)?.IsChecked,
                Difficulty = Difficulty.IsEnabled ? (Difficulty.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Easy" : "Easy"
            };

            StartGameClicked?.Invoke(this, args);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                Difficulty.IsEnabled = radioButton.Content.ToString() == "Play Against the Computer";
            }
        }
    }
}
