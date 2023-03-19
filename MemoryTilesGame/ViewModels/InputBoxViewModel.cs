using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace MemoryTiles.ViewModels
{
    public class InputBoxViewModel
    {
        public string Username { get; set; }

        public ICommand SaveImagePathCommand => new SaveCommand(
            commandParameter => ExecuteImagePathSave(commandParameter as string));

        private void ExecuteImagePathSave(string destinationFilePath)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                UserDataMessage message = new UserDataMessage { Username = Username, ImagePath = destinationFilePath };
                MessagingCenter.Send(this, "UserDataMessage", message);
            }
        }
    }

    public class UserDataMessage
    {
        public string Username { get; set; }
        public string ImagePath { get; set; }
    }

    public class SaveCommand : ICommand
    {
        private Action<string> _executeAction;

        public SaveCommand(Action<string> executeAction)
        {
            _executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter as string);
        }

        public event EventHandler CanExecuteChanged;
    }
}
