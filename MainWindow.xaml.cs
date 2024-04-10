using System.Windows;

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
            WelcomeView welcomeView = new WelcomeView();
            welcomeView.StartGameClicked += WelcomeView_StartGameClicked;
            MainContent.Content = welcomeView;
        }

        private void WelcomeView_StartGameClicked(object sender, System.EventArgs e)
        {
            GameView gameView = new GameView();
            MainContent.Content = gameView;
        }
    }
}
