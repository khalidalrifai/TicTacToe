using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class GameView : UserControl
    {
        private enum CellState { Empty, X, O }
        private enum GameState { Running, Win, Draw }
        private CellState[,] boardState = new CellState[3, 3];
        private bool isPlayerOneTurn = true;

        public GameView()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                var button = (Button)FindName($"Button{i}");
                if (button != null)
                {
                    button.Content = string.Empty;
                    button.Click -= Button_Click;
                    button.Click += Button_Click;
                }
            }
            Array.Clear(boardState, 0, boardState.Length);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag != null && int.TryParse(button.Tag.ToString(), out int index))
            {
                int row = index / 3;
                int col = index % 3;

                if (boardState[row, col] == CellState.Empty)
                {
                    boardState[row, col] = isPlayerOneTurn ? CellState.X : CellState.O;
                    button.Content = isPlayerOneTurn ? "X" : "O";
                    UpdateGameState(row, col);
                }
            }
        }

        private void UpdateGameState(int lastRow, int lastCol)
        {
            var state = CheckGameState(lastRow, lastCol);
            switch (state)
            {
                case GameState.Win:
                    MessageBox.Show(isPlayerOneTurn ? "Player X Wins!" : "Player O Wins!");
                    ResetBoard();
                    break;
                case GameState.Draw:
                    MessageBox.Show("It's a draw!");
                    ResetBoard();
                    break;
                case GameState.Running:
                    isPlayerOneTurn = !isPlayerOneTurn;
                    break;
            }
        }

        private GameState CheckGameState(int lastRow, int lastCol)
        {
            if (RowColDiagWin(lastRow, lastCol))
            {
                return GameState.Win;
            }
            
            if (IsBoardFull())
            {
                return GameState.Draw;
            }
            return GameState.Running;
        }

        private bool RowColDiagWin(int row, int col)
        {
            var player = boardState[row, col];
            
            if (boardState[row, 0] == player && boardState[row, 1] == player && boardState[row, 2] == player ||
                boardState[0, col] == player && boardState[1, col] == player && boardState[2, col] == player)
            {
                return true;
            }
            
            if (boardState[0, 0] == player && boardState[1, 1] == player && boardState[2, 2] == player ||
                boardState[0, 2] == player && boardState[1, 1] == player && boardState[2, 0] == player)
            {
                return true;
            }
            return false;
        }

        private bool IsBoardFull() => boardState.Cast<CellState>().All(state => state != CellState.Empty);

        private void ResetBoard()
        {
            InitializeBoard(); 
            isPlayerOneTurn = true;
        }
    }
}
