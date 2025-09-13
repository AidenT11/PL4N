using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PL4N_App
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            if (WindowState == WindowState.Normal)
            {
                MaximiseEmoji = "1";
            }
            else if (WindowState == WindowState.Maximized)
            {
                MaximiseEmoji = "2";
            }
        }

        private string maximiseEmoji;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string MaximiseEmoji
        {
            get { return maximiseEmoji; }
            set { maximiseEmoji = value; }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaximise_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                MaximiseEmoji = "1";
            }
            else
            {
                WindowState = WindowState.Maximized;
                MaximiseEmoji = "2";
            }
            OnPropertyChanged("MaximiseEmoji");
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}