using System;
using System.Windows;
using System.Windows.Threading;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private DispatcherTimer _timer;
        private TimeSpan _timeElapsed;
        private bool _isRunning;
        private const int TimerIntervalMs = 10;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            UpdateTimeDisplay();
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(TimerIntervalMs);
            _timer.Tick += Timer_Tick;
            _timeElapsed = TimeSpan.Zero;
            _isRunning = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromMilliseconds(TimerIntervalMs));
            UpdateTimeDisplay();
        }

        private void UpdateTimeDisplay()
        {
            TimeDisplay.Text = _timeElapsed.ToString(@"hh\:mm\:ss\:ff");
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                _timer.Stop();
                StartStopButton.Content = "Start";
            }
            else
            {
                _timer.Start();
                StartStopButton.Content = "Stop";
            }

            _isRunning = !_isRunning;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _timeElapsed = TimeSpan.Zero;
            UpdateTimeDisplay();
            StartStopButton.Content = "Start";
            _isRunning = false;
        }
    }
}