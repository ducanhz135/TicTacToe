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
        string Cross = "X";
        string Nought = "O";

        private MarkType[] results;

        private bool isPlayer1Turn;

        private bool isGameEnded;

        private string _ButtonContent;
        public string ButtonContent { get => _ButtonContent; set { _ButtonContent = value; OnPropertyChanged(); } }

        private string _ButtonContent1;
        public string ButtonContent1 { get => _ButtonContent1; set { _ButtonContent1 = value; OnPropertyChanged(); } }

        private string _ButtonContent2;
        public string ButtonContent2 { get => _ButtonContent2; set { _ButtonContent2 = value; OnPropertyChanged(); } }

        private string _ButtonContent3;
        public string ButtonContent3 { get => _ButtonContent3; set { _ButtonContent3 = value; OnPropertyChanged(); } }

        private string _ButtonContent4;
        public string ButtonContent4 { get => _ButtonContent4; set { _ButtonContent4 = value; OnPropertyChanged(); } }

        private string _ButtonContent5;
        public string ButtonContent5 { get => _ButtonContent5; set { _ButtonContent5 = value; OnPropertyChanged(); } }

        private string _ButtonContent6;
        public string ButtonContent6 { get => _ButtonContent6; set { _ButtonContent6 = value; OnPropertyChanged(); } }

        private string _ButtonContent7;
        public string ButtonContent7 { get => _ButtonContent7; set { _ButtonContent7 = value; OnPropertyChanged(); } }

        private string _ButtonContent8;
        public string ButtonContent8 { get => _ButtonContent8; set { _ButtonContent8 = value; OnPropertyChanged(); } }

        public ICommand TickCommand { get; set; }
        public ICommand TickCommand1 { get; set; }
        public ICommand TickCommand2 { get; set; }
        public ICommand TickCommand3 { get; set; }
        public ICommand TickCommand4 { get; set; }
        public ICommand TickCommand5 { get; set; }
        public ICommand TickCommand6 { get; set; }
        public ICommand TickCommand7 { get; set; }
        public ICommand TickCommand8 { get; set; }

        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            TickCommand = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {

                SetContentToResults(button);

                ButtonContent = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand1 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent1 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand2 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent2 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand3 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent3 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand4 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent4 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand5 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent5 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand6 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent6 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand7 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent7 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });

            TickCommand8 = new RelayCommand<System.Windows.Controls.Button>((p) => { return true; }, (button) => {


                SetContentToResults(button);

                ButtonContent8 = isPlayer1Turn ? Cross : Nought;

                DefineNextPlayerOrWinner();
            });



            LoadedWindowCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {

                if (p == null)
                    return;

                FreeResults();

            });

        }

        private void NewGame()
        {
            FreeResults();

            isGameEnded = false;
        }


        private void FreeResults()
        {
            results = new MarkType[9];

            for (var i = 0; i < results.Length; i++)
                results[i] = MarkType.Free;

            isPlayer1Turn = true;

            ButtonContent = string.Empty;
            ButtonContent1 = string.Empty;
            ButtonContent2 = string.Empty;
            ButtonContent3 = string.Empty;
            ButtonContent4 = string.Empty;
            ButtonContent5 = string.Empty;
            ButtonContent6 = string.Empty;
            ButtonContent7 = string.Empty;
            ButtonContent8 = string.Empty;

        }

        private void CheckForWinner()
        {

            #region Horizontal Wins

            if (IsGameWon())
            {
                isGameEnded = true;
                
            }


            if (IsGameWon())
            {
                isGameEnded = true;

            }

            if (IsGameWon())
            {
                isGameEnded = true;

            }

            #endregion

            #region Vertical Wins

            if (IsGameWon())
            {

                isGameEnded = true;

            }

            if (IsGameWon())
            {

                isGameEnded = true;
                
            }

            if (IsGameWon())
            {

                isGameEnded = true;
                
            }

            #endregion

            #region Diagonal Wins

            if (IsGameWon())
            {

                isGameEnded = true;

            }

            if (IsGameWon())
            {
                isGameEnded = true;

            }

            #endregion

            #region No Winners


            if (!results.Any(f => f == MarkType.Free))
            {

                isGameEnded = true;

            }

            #endregion

            
        }

        private void SetContentToResults(Button button)
        {
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (results[index] != MarkType.Free)
                return;

            results[index] = isPlayer1Turn ? MarkType.Cross : MarkType.Nought;
        }

        private void DefineNextPlayerOrWinner()
        {

            CheckForWinner();

            if (isGameEnded)
            {
                MessageBox.Show((isPlayer1Turn ? "Player 1" : "Player 2") + " won the game");
            }

            isPlayer1Turn ^= true;

            if (isGameEnded)
            {
                NewGame();
            }
        }

        private bool IsGameWon()
        {
            return (results[0] != MarkType.Free && (results[0] & results[1] & results[2]) == results[0])
                || (results[3] != MarkType.Free && (results[3] & results[4] & results[5]) == results[3])
                || (results[6] != MarkType.Free && (results[6] & results[7] & results[8]) == results[6])
                || (results[0] != MarkType.Free && (results[0] & results[3] & results[6]) == results[0])
                || (results[1] != MarkType.Free && (results[1] & results[4] & results[7]) == results[1])
                || (results[2] != MarkType.Free && (results[2] & results[5] & results[8]) == results[2])
                || (results[0] != MarkType.Free && (results[0] & results[4] & results[8]) == results[0])
                || (results[2] != MarkType.Free && (results[2] & results[4] & results[6]) == results[2]);
        }
    }
}
