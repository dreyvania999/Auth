using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CAPTCHA.xaml
    /// </summary>
    public partial class CAPTCHA : Window
    {
        private static string CapthaText ="";
        private Random random;
        private int CapchaHeight;
        private int CapchaWidth;
        public CAPTCHA()
        {
            InitializeComponent();
            GenerateCaptha();
        }

        void GenerateCaptha()
        {
            random = new Random();
            CapchaHeight = (int)CAPTCHACanva.Height;
            CapchaWidth = (int)CAPTCHACanva.Width;
            int sizeSTR = random.Next(7, 11);
            while (CapthaText.Length < sizeSTR)
            {
                if (random.Next(1, 3) == 1)
                {
                    CapthaText += (char)random.Next(48, 58);
                }
                else
                {
                    CapthaText += (char)random.Next(65, 92);
                }
            }
            int i = 0;
            while (sizeSTR > i)
            {
                Line l = new Line()
                {
                    X1 = random.Next(CapchaWidth),
                    Y1 = random.Next(CapchaHeight),
                    X2 = random.Next(CapchaWidth),
                    Y2 = random.Next(CapchaHeight),
                    StrokeThickness = random.Next(1, 5),
                    Stroke = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 233))),
                };
                CAPTCHACanva.Children.Add(l);
                i++;
            }

            int LeftPositionText = (int)(CapchaWidth - 20) / (sizeSTR + 5);
            int currentLeftPosition = 10;
            foreach (var item in CapthaText)
            {
                TextBlock tb = new TextBlock()
                {
                    Text = item.ToString(),
                    FontSize = 26
                };
                switch (random.Next(1, 4))
                {
                    case 1:
                        tb.FontStyle = FontStyles.Italic;
                        break;
                    case 2:
                        tb.FontWeight = FontWeights.Bold;
                        break;
                    default:
                        tb.FontWeight = FontWeights.Bold;
                        tb.FontStyle = FontStyles.Italic;
                        break;
                }
                CAPTCHACanva.Children.Add(tb);


                Canvas.SetLeft(tb, currentLeftPosition);
                currentLeftPosition = random.Next(currentLeftPosition, LeftPositionText) + 10;
                LeftPositionText = currentLeftPosition + ((CapchaWidth - 20) / sizeSTR);

                Canvas.SetTop(tb, random.Next(CapchaHeight / 3, (CapchaHeight / 6) * 4));
            }
        }       

        private void CheckCaptha_Click(object sender, RoutedEventArgs e)
        {           
            if (textCaptha.Text.ToLower() == CapthaText.ToLower())
            {
                MessageBox.Show("Вы прошли проверку");
            }
            else
            {
                MessageBox.Show("Неверно введено значение");
            }
        }
    }
}
