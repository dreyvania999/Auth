using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new();
        private readonly DispatcherTimer dispatcherTimer = new();
        public static string GlobalNumbers;
        int time = 0;

        
        private void setVisibility()
        {
            StaticBlocedString.Visibility = Visibility.Visible;
            EditingBlocedString.Visibility = Visibility.Visible;
        }

        private void setUsability(object sender, EventArgs e)
        {
            
        }
        private void setNewText(object sender, EventArgs e)
        {
            EditingBlocedString.Text = time++
        }
        public MainWindow()
        {
            InitializeComponent();

        }

        private void SartAutorization_Click(object sender, RoutedEventArgs e)
        {
            Random random = new();
            GlobalNumbers = random.Next(10000, 100000).ToString();
            MessageBoxResult result;
            result = MessageBox.Show(GlobalNumbers);
            if (result != 0)
            {
                Autentification1 taskWindow = new()
                {
                    Owner = this
                };
                bool? d = taskWindow.ShowDialog();
                if (d.HasValue && d.Value)
                {
                    setVisibility();
                    timer.Interval = new TimeSpan(0, 0, 10);
                    timer.Tick += new EventHandler(setUsability);
                    timer.Start();

                    
                    dispatcherTimer.Tick += new EventHandler();
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Start();
                }

            }
            
        }
    }
}
