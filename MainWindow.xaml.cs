using System.Windows;
using TicTacToe;

namespace TicTacToe
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowWelcomeView();
        }

        private void ShowWelcomeView()
        {
            // Initialize the WelcomeView
            WelcomeView welcomeView = new WelcomeView();
            // Subscribe to the StartGameClicked event
            welcomeView.StartGameClicked += WelcomeView_StartGameClicked;
            // Set the WelcomeView as the content of the MainContent Control
            MainContent.Content = welcomeView;
        }

        private void WelcomeView_StartGameClicked(object sender, System.EventArgs e)
        {
            // Initialize the GameView
            GameView gameView = new GameView();
            // Set the GameView as the content of the MainContent Control
            MainContent.Content = gameView;
        }
    }
}
