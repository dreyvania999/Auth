using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Autentification1.xaml
    /// </summary>
    public partial class Autentification1 : Window
    {
        static bool IsBlocedState = false;
        DispatcherTimer timer = new();
        public Autentification1()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(BackToMainWindow);
            timer.Start();
        }

        private void BackToMainWindow(object sender, EventArgs e)
        {
            MessageBox.Show("Время вышло ");
            IsBlocedState = true;
            DialogResult = IsBlocedState;
            MainWindow.IsRunningSecond++;
            timer.Stop();
            Close();
        }

        private void FiveSignsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FiveSignsBox.Text.Length < 5)
            {
                return;
            }
            if (MainWindow.GlobalNumbers == FiveSignsBox.Text)
            {
                MessageBox.Show("все норм");
                MainWindow.IsRunningSecond = 0;
                DialogResult = IsBlocedState;
                timer.Stop();
                Close();
            }
            else
            {
                MessageBox.Show("Введенные значения не совпадпют с ранее продемонстрированными данными");
                IsBlocedState = true;
                MainWindow.IsRunningSecond++;
                DialogResult = IsBlocedState;
                timer.Stop();
                Close();
            }

        }
    }
}
