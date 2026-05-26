using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task1.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }
        public void Execute(object parameter) => execute();
        public bool CanExecute(object parameter) => true;
        public event EventHandler CanExecuteChanged;
    }
}
