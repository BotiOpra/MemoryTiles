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

namespace MemoryTilesGame.Views
{
    /// <summary>
    /// Interaction logic for GameInputBox.xaml
    /// </summary>
    public partial class GameInputBox : Window
    {
        public bool IsOkPressed { get; set; } = false;

        public GameInputBox()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            IsOkPressed= true;
            Close();
        }
    }
}
