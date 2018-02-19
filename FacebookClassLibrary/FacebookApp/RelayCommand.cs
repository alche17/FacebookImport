using System;
using System.Windows.Input;

namespace FacebookApp
{
    public class RelayCommand : ICommand
    {
        public ViewModelBase vmclass { get; set; }

        public RelayCommand(ViewModelBase vmb)
        {
            vmclass = vmb;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            vmclass.OnCommand();
        }
    }
}
