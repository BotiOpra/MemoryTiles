using MemoryTiles.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace MemoryTiles
{
    public partial class InputBox : Window
    {

        public static readonly DependencyProperty DestinationPathProperty = DependencyProperty.Register(
            "DestinationPath",
            typeof(string),
            typeof(InputBox),
            new PropertyMetadata(default(string)));

        public string DestinationPath
        {
            get => (string)GetValue(DestinationPathProperty);
            set => SetValue(DestinationPathProperty, value);
        }

        public InputBox()
        {
            InitializeComponent();
        }

        public bool HasImage()
        {
            return string.IsNullOrEmpty(DestinationPath);
        }

        public bool HasValue()
        {
            return string.IsNullOrEmpty(userTextBox.Text);
        }

        public string InputTextValue()
        {
            return userTextBox.Text;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg;*.jpg;*.gif";
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            DestinationPath = openFileDialog.FileName;
        }
    }
}
