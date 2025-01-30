using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SampleBrowser
{
    public class Command : ICommand
    {
        private Action execute;
        private bool canExecute = true;

        public event EventHandler CanExecuteChanged;

        public Command(Action action)
        {
            execute = action;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            changeCanExecute(true);
            execute.Invoke();
        }

        private void changeCanExecute(bool canExecute)
        {
            this.canExecute = canExecute;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
