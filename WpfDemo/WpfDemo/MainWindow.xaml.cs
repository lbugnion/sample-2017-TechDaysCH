using System.Windows;
using System.Windows.Media.Animation;
using Helpers;

namespace WpfDemo
{
    public partial class MainWindow : Window
    {
        private Storyboard _sbd;
        private int _counter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            if (_sbd == null)
            {
                _sbd = (Storyboard)Resources["BallStoryboard"];
            }

            _sbd.Stop();
            _sbd.Begin();

            var message = $"Submit clicked {++_counter} times";
            TileHelper.ShowTileNotification(message);
            ToastHelper.PopToast("TechDays!!", message);
        }
    }
}
