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

         private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
