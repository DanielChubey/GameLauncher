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

           
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(60);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        
        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progress < 100)
            {
                
                progress += 1;

                
                DoubleAnimation animation = new DoubleAnimation(progressBar.Value, progress, TimeSpan.FromMilliseconds(50));
                progressBar.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, animation);

               
                if (statusIndex < statusMessages.Length)
                {
                    statusText.Text = statusMessages[statusIndex];
                    if (progress >= (statusIndex + 1) * 20) 
                    {
                        statusIndex++;
                    }
                }
            }
            else
            {
                timer.Stop();

                
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
