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
    /// <summary>
    /// Interaction logic for InGameUserInfoFrame.xaml
    /// </summary>
    public partial class InGameUserInfoFrame : UserControl
    {
        public static readonly DependencyProperty ProfileImageProperty =
        DependencyProperty.Register("ProfileImage", typeof(ImageSource), typeof(InGameUserInfoFrame), new PropertyMetadata(null));

        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(InGameUserInfoFrame), new PropertyMetadata(null));

        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register("Level", typeof(string), typeof(InGameUserInfoFrame), new PropertyMetadata(null));

        public string Level
        {
            get { return (string)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        public ImageSource ProfileImage
        {
            get { return (ImageSource)GetValue(ProfileImageProperty); }
            set { SetValue(ProfileImageProperty, value); }
        }

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public InGameUserInfoFrame()
        {
            InitializeComponent();
        }
    }
}
