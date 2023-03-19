using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        private string _username;
        private uint _nrGames;
        private uint _curLevel;
        private string _imagePath;

        public UserModel(string username)
        {
            _username = username;
            _nrGames = 0;
            _curLevel = 0;
            _imagePath = @"../Images/genericPic.png";
        }

        public UserModel(string username, string imagePath)
        {
            _username = username;
            _nrGames = 0;
            _curLevel = 0;
            _imagePath = imagePath;
        }

        public UserModel(string username, uint nrGames, uint level, string imagePath)
        {
            _username = username;
            _nrGames = nrGames;
            _curLevel = level;
            _imagePath = imagePath;
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public uint NrGames
        {
            get { return _nrGames; }
            set
            {
                _nrGames = value;
                OnPropertyChanged("NrGames");
            }
        }

        public uint Level
        {
            get { return _curLevel; }
            set
            {
                _curLevel = value;
                OnPropertyChanged("Level");
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath= value;
                OnPropertyChanged("ImagePath");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
