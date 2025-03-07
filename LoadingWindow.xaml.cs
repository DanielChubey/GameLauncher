using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace GameLauncher
{
    public partial class LoadingWindow : Window
    {
        private DispatcherTimer timer;
        private int progress = 0;
        private string[] statusMessages = {
            "Checking system requirements...",
            "Checking components...",
            "Loading assets...",
            "Preparing game...",
            "Starting game..."
        };
        private int statusIndex = 0;

        public LoadingWindow()
        {
            InitializeComponent();

            // Timer for smooth progress
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1200);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progress < 100)
            {
                progress += 20; // Increase progress smoothly

                // Animate the progress bar
                DoubleAnimation animation = new DoubleAnimation(progressBar.Value, progress, TimeSpan.FromSeconds(1));
                progressBar.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, animation);

                // Update the status text
                if (statusIndex < statusMessages.Length)
                {
                    statusText.Text = statusMessages[statusIndex++];
                }
            }
            else
            {
                timer.Stop();

                // Smoothly fade out the loading screen
                DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
                fadeOut.Completed += (s, a) =>
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                };
                this.BeginAnimation(Window.OpacityProperty, fadeOut);
            }
        }
    }
}
