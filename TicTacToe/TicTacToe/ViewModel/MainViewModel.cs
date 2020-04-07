using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicTacToe.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public ICommand TickCommand { get; set; }

        public MainViewModel()
        {
            TickCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                MessageBox.Show("Ok");
            });
        }
    }
}
