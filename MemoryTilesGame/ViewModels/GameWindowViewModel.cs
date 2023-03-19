using MemoryTiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTilesGame.ViewModels
{
    public class GameWindowViewModel
    {
        public UserModel CurrentUser { get; set; }

        public GameWindowViewModel() { }

        public GameWindowViewModel(UserModel currentUser)
        {
            CurrentUser = currentUser;
        }
    }
}
