using System;
using System.Diagnostics;
using System.Windows;
using Microsoft.Win32;

namespace GameLauncher
{
    public partial class MainWindow : Window
    {
        private string selectedGamePath = "";  // Holds the selected game path

        public MainWindow()
        {
            InitializeComponent();
        }

        // Add Game Button Click (Functionality same as Select Game)
        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe)|*.exe",  // Filters only executable files
                Title = "Select a Game to Add"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedGamePath = openFileDialog.FileName; // Set the selected game's path
                PlayButton.IsEnabled = true; // Enable the Play button after adding a game
                MessageBox.Show("Game added: " + selectedGamePath, "Game Added", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Play Button Click (Launch Game)
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedGamePath))  // Ensure a game is selected
            {
                try
                {
                    Process.Start(selectedGamePath);  // Launch the selected game
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error launching game: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please add a game first!", "No Game Added", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
