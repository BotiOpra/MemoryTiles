using MemoryTilesGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace MemoryTilesGame.Views
{
    /// <summary>
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        public GamePlayPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;
            PictureViewModel clickedTile = clicked.DataContext as PictureViewModel;

            GamePlayViewModel game = DataContext as GamePlayViewModel;
            game.TileClicked(clickedTile);
            
        }

        private void ToMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ToNextLvlBtn_Click(object sender, RoutedEventArgs e)
        {
            GamePlayViewModel currentDataContext = DataContext as GamePlayViewModel;
            int nrRows = currentDataContext.NrRows;
            int nrColumns = currentDataContext.NrColumns;

            DataContext = new GamePlayViewModel(nrRows, nrColumns);
        }
    }
}
