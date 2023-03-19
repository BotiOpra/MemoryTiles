using GalaSoft.MvvmLight.Command;
using MemoryTiles.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemoryTiles.ViewModels
{
    public class StartPageViewModel
    {
        private ObservableCollection<UserModel> _usersList;

        private UserModel _selectedUser;
        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
            }
        }

        public ListUpdateCommand deleteUserCommand { get; }

        public RelayCommand<ICloseable> PlayGameCommand { get; private set; }

        public ObservableCollection<UserModel> Users
        {
            get { return _usersList; }
            set { _usersList = value; }
        }

        public StartPageViewModel()
        {
            _usersList = new ObservableCollection<UserModel>();
            deleteUserCommand = new ListUpdateCommand(() =>
            {
                if (_selectedUser != null)
                    _usersList.Remove(_selectedUser);
            });

            PlayGameCommand = new RelayCommand<ICloseable>(OpenGameWindow);

            MessagingCenter.Subscribe<InputBoxViewModel, UserDataMessage>(this, "UserDataMessage", (sender, message) =>
            {
                AddUser(message.Username, message.ImagePath);
            });
        }

        public void OpenGameWindow(ICloseable window)
        {

            Views.GameWindow gameWindow = new Views.GameWindow(SelectedUser);
            if(window != null)
            {
                window.Close();
            }
            gameWindow.Show();
        }

        public void AddUser(string username, string imagePath)
        {
            if (!String.IsNullOrEmpty(imagePath))
            {
                string workingPath = Directory.GetCurrentDirectory() + @"\Images\" + Path.GetFileName(imagePath);
                if (!File.Exists(workingPath))
                    File.Copy(imagePath, workingPath);
                _usersList.Add(new UserModel(username, workingPath));
            }
            else
            {
                _usersList.Add(new UserModel(username));
            }
        }
    }

    public class ListUpdateCommand : ICommand
    {
        private Action _executeAction;

        public ListUpdateCommand(Action executeAction)
        {
            _executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
