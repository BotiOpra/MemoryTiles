using MemoryTiles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryTiles
{
    public interface ICloseable
    {
        void Close();
    }

    public partial class MainWindow : Window, ICloseable
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void prevImgBtn_Click(object sender, RoutedEventArgs e)
        {
            int currentIdx = userListView.SelectedIndex;
            int nrItems = userListView.Items.Count;
            // there are no selected items
            if (nrItems == 0)
                return;
            if (currentIdx == -1)
            {
                userListView.SelectedIndex = 0;
                return;
            }
            if (currentIdx == 0)
            {
                userListView.SelectedIndex = nrItems - 1;
                return;
            }
            userListView.SelectedIndex = currentIdx - 1;
        }

        private void nextImgBtn_Click(object sender, RoutedEventArgs e)
        {
            int currentIdx = userListView.SelectedIndex;
            int nrItems = userListView.Items.Count;
            if (nrItems == 0)
                return;
            if (currentIdx == -1)
            {
                userListView.SelectedIndex = 0;
                return;
            }
            if (currentIdx == userListView.Items.Count - 1)
            {
                userListView.SelectedIndex = 0;
                return;
            }
            userListView.SelectedIndex = currentIdx + 1;
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            Views.GameWindow gameWindow = new Views.GameWindow();
            gameWindow.Show();

            Close();
        }

        private void newUserBtn_Click(object sender, RoutedEventArgs e)
        {
            InputBox inputBox = new InputBox();
            inputBox.ShowDialog();
        }
    }
}
