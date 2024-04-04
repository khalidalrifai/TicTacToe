using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class GameView : UserControl
    {
        private bool isPlayerOneTurn = true;
        private Button[,] boardButtons = new Button[3, 3];

        public GameView()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            boardButtons[0, 0] = Button0;
            boardButtons[0, 1] = Button1;
            boardButtons[0, 2] = Button2;
            boardButtons[1, 0] = Button3;
            boardButtons[1, 1] = Button4;
            boardButtons[1, 2] = Button5;
            boardButtons[2, 0] = Button6;
            boardButtons[2, 1] = Button7;
            boardButtons[2, 2] = Button8;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content == null)
            {
                button.Content = isPlayerOneTurn ? "X" : "O";
                if (CheckForWinner())
                {
                    MessageBox.Show(isPlayerOneTurn ? "Player 1 Wins!" : "Player 2 Wins!");
                    ResetBoard();
                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!");
                    ResetBoard();
                }
                isPlayerOneTurn = !isPlayerOneTurn;
            }
        }

        private bool CheckForWinner()
        {
            // Check rows and columns for a win
            for (int i = 0; i < 3; i++)
            {
                if (AreButtonsEqual(boardButtons[i, 0], boardButtons[i, 1], boardButtons[i, 2]) ||
                    AreButtonsEqual(boardButtons[0, i], boardButtons[1, i], boardButtons[2, i]))
                {
                    return true;
                }
            }
            // Check diagonals for a win
            if (AreButtonsEqual(boardButtons[0, 0], boardButtons[1, 1], boardButtons[2, 2]) ||
                AreButtonsEqual(boardButtons[0, 2], boardButtons[1, 1], boardButtons[2, 0]))
            {
                return true;
            }
            return false;
        }

        private bool AreButtonsEqual(Button b1, Button b2, Button b3)
        {
            return b1.Content != null && b1.Content.Equals(b2.Content) && b2.Content.Equals(b3.Content);
        }

        private bool IsBoardFull()
        {
            foreach (var button in boardButtons)
            {
                if (button.Content == null) return false;
            }
            return true;
        }

        private void ResetBoard()
        {
            foreach (var button in boardButtons)
            {
                button.Content = null;
            }
            isPlayerOneTurn = true;
        }
    }
}
