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
        private readonly DispatcherTimer dispatcherTimer = new();
        public static int IsRunningSecond = 0;
        public static string GlobalNumbers;
        private int time = 4;

        private string login = "login1";
        private string password = "0000"; 
        private void setVisibility()
        {
            StaticBlocedString.Visibility = Visibility.Visible;
            EditingBlocedString.Visibility = Visibility.Visible;
            SartAutorization.IsEnabled = false;
            time = 4;
        }
        private void setInVisibility()
        {
            StaticBlocedString.Visibility = Visibility.Collapsed;
            EditingBlocedString.Visibility = Visibility.Collapsed;
            SartAutorization.IsEnabled = true;

        }

        private void UpdateTime(object sender, EventArgs e)
        {
            time--;
            EditingBlocedString.Text = time.ToString() + " сек";
            if (time == 0)
            {
                dispatcherTimer.Stop();
                setInVisibility();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            NewAuthCode.Visibility = Visibility.Collapsed;

        }

        private void SartAutorization_Click(object sender, RoutedEventArgs e)
        {
            if (IsRunningSecond < 1)
            {
                if (UserLogin.Text != login || UserPassword.Password != password)
                {
                    MessageBox.Show("Проверьте введенные данные");
                    return;
                }

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

                        dispatcherTimer.Tick += new EventHandler(UpdateTime);
                        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                        dispatcherTimer.Start();
                        NewAuthCode.Visibility = Visibility.Visible;
                        SartAutorization.IsEnabled = false;

                    }                   

                }
            }
                     
        }

        private void NewAuthCode_Click(object sender, RoutedEventArgs e)
        {
            if (IsRunningSecond < 2)
            {
                if (UserLogin.Text != login || UserPassword.Password != password)
                {
                    MessageBox.Show("Проверьте введенные данные");
                    return;
                }

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
                        CAPTCHA CAPTCHAWindow = new()
                        {
                            Owner = this
                        };
                        bool? s = CAPTCHAWindow.ShowDialog();

                        SartAutorization.IsEnabled = false;
                    }

                }
                NewAuthCode.Visibility = Visibility.Collapsed;
            }
            
        }
    }
}
