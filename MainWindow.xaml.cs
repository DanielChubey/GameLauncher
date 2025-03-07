using System;
using System.Diagnostics;
using System.Windows;
using Microsoft.Win32;

namespace GameLauncher
{
    public partial class MainWindow : Window
    {
        private string selectedGamePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Select Game Button Click
        private void SelectGame_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe)|*.exe",
                Title = "Select a Game to Launch"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedGamePath = openFileDialog.FileName;
                PlayButton.IsEnabled = true; // Enable Play button after selecting a game
                MessageBox.Show("Game selected: " + selectedGamePath, "Game Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Play Button Click (Launch Game)
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedGamePath))
            {
                try
                {
                    Process.Start(selectedGamePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error launching game: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a game first!", "No Game Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
