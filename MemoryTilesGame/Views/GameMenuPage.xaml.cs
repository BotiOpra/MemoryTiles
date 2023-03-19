using MemoryTiles;
using MemoryTilesGame.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryTilesGame.Views
{
    public partial class GameMenuPage : Page
    {
        public GameMenuPage()
        {
            
            InitializeComponent();
        }

        private void newGameBtn_Click(object sender, RoutedEventArgs e)
        {
            GameInputBox input = new GameInputBox();
            input.ShowDialog();

            if(input.IsOkPressed)
            {
                var inputDataContext = input.DataContext as GameInputBoxViewModel;

                int nrRows = inputDataContext.RowValue;
                int nrCols = inputDataContext.ColumnValue;

                GamePlayPage game = new GamePlayPage
                {
                    DataContext = new GamePlayViewModel(nrRows, nrCols)
                };

                NavigationService.Navigate(game);
            }

        }
    }
}
