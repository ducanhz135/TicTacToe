using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using TicTacToe.Model;
using System.Windows.Media;
using System.Collections.Generic;

namespace TicTacToe.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] results;

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's turn (O)
        /// </summary>
        private bool isPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool isGameEnded;


        public ICommand TickCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            TickCommand = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {

                

                // Find the buttons position in the array
                var column = Grid.GetColumn(button);
                var row = Grid.GetRow(button);

                var index = column + (row * 3);

                // Don't do anything if the cell already has a value in it
                if (results[index] != MarkType.Free)
                    return;

                // Set the cell value based on which players turn it is
                results[index] = isPlayer1Turn ? MarkType.Cross : MarkType.Nought;

                // Set button text to the result
                button.Content = isPlayer1Turn ? "X" : "O";

                // Change noughts to green
                if (!isPlayer1Turn)
                    button.Foreground = Brushes.Red;

                // Check for a winner
                var grid = button.Parent as Grid;
                CheckForWinner(grid);

                // show the winner
                if (isGameEnded)
                {
                    MessageBox.Show((isPlayer1Turn ? "Player 1" : "Player 2" )+ " won the game");
                }

                // Toggle the players turns
                isPlayer1Turn ^= true;

                // Start a new game on the click after it finished
                if (isGameEnded)
                {
                    NewGame(button.Parent as Grid);
                }
            });

            LoadedWindowCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {

                if (p == null)
                    return;

                FreeResults();

                p.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    // Change background, foreground and content to default values
                    button.Content = string.Empty;
                    button.Background = Brushes.White;
                    button.Foreground = Brushes.Blue;
                });

            });

        }

        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>
        private void NewGame(Grid grid)
        {
            FreeResults();

            // Interate every button on the grid...
            grid.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Make sure the game hasn't finished
            isGameEnded = false;
        }

        private void FreeResults()
        {
            // Create a new blank array of free cells
            results = new MarkType[9];

            for (var i = 0; i < results.Length; i++)
                results[i] = MarkType.Free;

            // Make sure Player 1 starts the game
            isPlayer1Turn = true;
        }

        /// <summary>
        /// Checks if there is a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner(Grid grid)
        {
            var buttons = grid.Children.Cast<Button>().ToList();

            //var btn = buttons.FirstOrDefault(x => x.Name == "Button0_0");
            #region Horizontal Wins

            // Check for horizontal wins
            //
            //  - Row 0
            //
            if (results[0] != MarkType.Free && (results[0] & results[1] & results[2]) == results[0])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                GetButtonByName(buttons, "Button0_0").Background = GetButtonByName(buttons, "Button1_0").Background = GetButtonByName(buttons, "Button2_0").Background = Brushes.Green;
                
            }

            //
            //  - Row 1
            //
            if (results[3] != MarkType.Free && (results[3] & results[4] & results[5]) == results[3])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                
                GetButtonByName(buttons, "Button0_1").Background = GetButtonByName(buttons, "Button1_1").Background = GetButtonByName(buttons, "Button2_1").Background = Brushes.Green;
            }
            //
            //  - Row 2
            //
            if (results[6] != MarkType.Free && (results[6] & results[7] & results[8]) == results[6])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                
                GetButtonByName(buttons, "Button0_2").Background = GetButtonByName(buttons, "Button1_2").Background = GetButtonByName(buttons, "Button2_2").Background = Brushes.Green;
            }

            #endregion

            #region Vertical Wins

            // Check for vertical wins
            //
            //  - Column 0
            //
            if (results[0] != MarkType.Free && (results[0] & results[3] & results[6]) == results[0])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                GetButtonByName(buttons, "Button0_0").Background = GetButtonByName(buttons, "Button0_1").Background = GetButtonByName(buttons, "Button0_2").Background = Brushes.Green;
            }
            //
            //  - Column 1
            //
            if (results[1] != MarkType.Free && (results[1] & results[4] & results[7]) == results[1])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                
                GetButtonByName(buttons, "Button1_0").Background = GetButtonByName(buttons, "Button1_1").Background = GetButtonByName(buttons, "Button1_2").Background = Brushes.Green;
            }
            //
            //  - Column 2
            //
            if (results[2] != MarkType.Free && (results[2] & results[5] & results[8]) == results[2])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                
                GetButtonByName(buttons, "Button2_0").Background = GetButtonByName(buttons, "Button2_1").Background = GetButtonByName(buttons, "Button2_2").Background = Brushes.Green;
            }

            #endregion

            #region Diagonal Wins

            // Check for diagonal wins
            //
            //  - Top Left Bottom Right
            //
            if (results[0] != MarkType.Free && (results[0] & results[4] & results[8]) == results[0])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                
                GetButtonByName(buttons, "Button0_0").Background = GetButtonByName(buttons, "Button1_1").Background = GetButtonByName(buttons, "Button2_2").Background = Brushes.Green;
            }
            //
            //  - Top Right Bottom Left
            //
            if (results[2] != MarkType.Free && (results[2] & results[4] & results[6]) == results[2])
            {
                // Game ends
                isGameEnded = true;

                // Highlight winning cells in green
                
                GetButtonByName(buttons, "Button2_0").Background = GetButtonByName(buttons, "Button1_1").Background = GetButtonByName(buttons, "Button0_2").Background = Brushes.Green;
            }

            #endregion

            #region No Winners

            // Check for no winner and full board
            if (!results.Any(f => f == MarkType.Free))
            {
                // Game ended
                isGameEnded = true;

                // Turn all cells orange
                buttons.ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }

            #endregion

            
        }

        private Button GetButtonByName(IList<Button> buttons, string name)
        {
            return buttons.FirstOrDefault(x => x.Name == name);
        }
    }
}
