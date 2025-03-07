using System.Windows;

namespace GameLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for Play button click
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            // Add code here to handle the button click (e.g., launch the game, open another window, etc.)
            MessageBox.Show("Play button clicked!");
        }
    }
}
