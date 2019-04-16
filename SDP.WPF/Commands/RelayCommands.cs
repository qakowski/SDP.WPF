using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SDP.WPF.Commands
{
    class RelayCommands : ICommand
    {

        public RelayCommands(Action<Object> execute) : this(execute, null)
        {

        }
        public RelayCommands(Action<Object> execute, Predicate<object> canExecute)
        {
            if (execute != null)
            {
                _execute = execute;
            }
            else
            {
                throw new ArgumentNullException("execute");
            }
            _canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
    }
}
