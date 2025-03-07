using System;
using System.Windows;
using System.Windows.Threading;  // For DispatcherTimer

namespace GameLauncher
{
    public partial class LoadingWindow : Window
    {
        private DispatcherTimer timer;
        private int progress = 0;

        public LoadingWindow()
        {
            InitializeComponent();
            
            // Initialize Timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50); // Adjust the interval for speed of progress
            timer.Tick += Timer_Tick;
            timer.Start();
            
            // Initial status text
            StatusText.Text = "Checking updates...";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progress < 100)
            {
                progress++;
                ProgressBar.Value = progress;

                // Update Status Text Dynamically
                if (progress < 30)
                {
                    StatusText.Text = "Checking updates...";
                }
                else if (progress < 60)
                {
                    StatusText.Text = "Setting up environment...";
                }
                else if (progress < 90)
                {
                    StatusText.Text = "Starting game...";
                }
                else
                {
                    StatusText.Text = "Complete!";
                }
            }
            else
            {
                timer.Stop(); 
                MainWindow mainWindow = new MainWindow(); 
                mainWindow.Show();
                this.Close(); 
            }
        }
    }
}
