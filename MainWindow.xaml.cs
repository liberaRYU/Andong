using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Windows.Threading;

namespace WpfApp5
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort serial;
        public MainWindow()
        {
            InitializeComponent();
            this.serial = new SerialPort(portName: $"COM9", baudRate: 9600, parity: Parity.None, dataBits: 8, stopBits: StopBits.One);
            this.serial.Encoding = Encoding.UTF8;
        }

        private void Button_Connect(object sender, RoutedEventArgs e)
        {
            this.serial.Open();
            if (this.serial.IsOpen)
            {
                MessageBox.Show(messageBoxText: $"시리얼 통신이 연결 되었습니다.");
                this.serial.DataReceived += Serial_DataReceived;
            }
            else
            {
                MessageBox.Show(messageBoxText: $"시리얼 통신이 안 되었습니다.");

            }

        }
        public static voud caller2()
        {
            Console.WriteLine($"Hello Git"); // Edit
        }

        private void Button_Disconnect(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(messageBoxText: $"연결을 종료합니다.");
            this.serial.Close();
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var string_builder = new StringBuilder();
            //var Temp = serial.ReadExisting();
            string_builder.Append(value: $"{serial.ReadExisting()}");
            this.Dispatcher.Invoke(callback: () =>
            {
                //this.TextBox_Window.Text = string_builder.ToString();

                if (String.IsNullOrEmpty(string_builder.ToString()))
                {
                    return;
                }
                else
                {
                    this.TextBox_Window.Text = string_builder.ToString();
                    //this.Temperature.Value = double.Parse(string_builder.ToString());
                }
            });
        }
    }
}
