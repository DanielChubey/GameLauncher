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

        
        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe)|*.exe", 
                Title = "Select a Game to Add"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedGamePath = openFileDialog.FileName; 
                PlayButton.IsEnabled = true;
                MessageBox.Show("Game added: " + selectedGamePath, "Game Added", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

       
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
                MessageBox.Show("Please add a game first!", "No Game Added", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
