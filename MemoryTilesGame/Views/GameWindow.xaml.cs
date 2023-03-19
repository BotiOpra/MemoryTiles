using MemoryTiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MemoryTiles.Views
{
    public partial class GameWindow : Window
    {
        public UserModel SelectedUser;

        public GameWindow()
        {
            InitializeComponent();
        }

        public GameWindow(UserModel user)
        {
            SelectedUser = user;
            InitializeComponent();
        }
    }
}
