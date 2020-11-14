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
using System.Timers;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

namespace SerialKiller
{
    // The interface is 9600 baud, 8 bit, no parity, 1 stop bit.
    public partial class SerialConnection
    {
        public bool isConnected = false;
        public SerialPort serialConnection = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        public bool hasError = false;
        public string errorMessage = "";

        public bool Connect()
        {
            try
            {
                serialConnection.ReadTimeout = 500;
                serialConnection.WriteTimeout = 500;
                serialConnection.Open();
                isConnected = true;
            }
            catch (Exception ex)
            {
                setError(true, ex.ToString());
            }
            return isConnected;
        }

        public void Close()
        {
            try
            {
                isConnected = false;
                serialConnection.Close();
            }
            catch (Exception ex)
            {
                setError(true, ex.ToString());
            }
        }

        private void setError(bool setError, string setMessage)
        {
            hasError = setError;
            errorMessage = setMessage;
            Console.WriteLine("Connection Error: {0}.", setMessage);
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialConnection serPort;
        //StringBuilder terminalText;
        string terminalText;
        //string enteredText;

        public MainWindow()
        {
            // Initialize Window
            InitializeComponent();
            serPort = new SerialConnection();
            //terminalText = new StringBuilder();
            terminalText = "";
            //enteredText = "";

            // Set Theme per Preference
            if (Properties.Settings.Default.Mode.ToString() == "dark")
            {
                AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, AdonisUI.ResourceLocator.DarkColorScheme);
            } else
            {
                AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, AdonisUI.ResourceLocator.LightColorScheme);
            }

            // Setup UI
            btn_Connect.IsEnabled = true;
            btn_Stop.IsEnabled = false;
            bar_Connect.Value = 0;
            lblStatus.Text = "Ready to connect.";
        }

        // Terminal Interaction
        private void txtTerminal_key_clicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    string oldString = terminalText;
                    string newString = txt_Terminal.Text;
                    Console.WriteLine("New String Length: {0}\tOld String Length: {1}", oldString.Length, newString.Length);
                    string difference = newString.Substring(oldString.Length, newString.Length-1);
                    Console.WriteLine(difference);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // Reading from Port
        public void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string inData = sp.ReadExisting();
            terminalText += inData + " ";
            Dispatcher.BeginInvoke(new Action(() => 
                { 
                    txt_Terminal.Text = terminalText; 
                    txt_Terminal.Select(txt_Terminal.Text.Length, 0);
                    txt_Terminal.Focus();
                }
            ));
        }

        // Connection
        private void btn_Connect_Clicked(object sender, RoutedEventArgs e)
        {
            // Variables
            string port = txt_Port.Text;
            var worker = new BackgroundWorker();

            serPort.serialConnection.DataReceived += new SerialDataReceivedEventHandler(dataReceived);

            // Connect
            if(serPort.Connect())
            {
                // Adjust UI
                btn_Connect.IsEnabled = false;
                btn_Stop.IsEnabled = true;
                txt_Terminal.Text = "";

                // Report
                lblStatus.Text = "Connected.";
                bar_Connect.Value = 100;
                bar_Connect.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                // On Error
                if(serPort.hasError)
                {
                    lblStatus.Text = serPort.errorMessage;
                    bar_Connect.Value = 100;
                    bar_Connect.Foreground = new SolidColorBrush(Colors.Red);
                    txt_Terminal.Text = serPort.errorMessage;
                }
            }
        }

        // Closing Operations
        private void btn_Stop_Clicked(object sender, RoutedEventArgs e)
        {
            if (serPort.isConnected)
            {
                serPort.Close();
                btn_Connect.IsEnabled = true;
                btn_Stop.IsEnabled = false;
                bar_Connect.Value = 0;
                lblStatus.Text = "Ready for Connection.";
            }
        }

        // Close Connection on any Close
        private void on_Window_Closing(object sender, CancelEventArgs e)
        {
            if (serPort.isConnected)
            {
                serPort.Close();
            }
        }

        /// <summary>
        /// Menu Item Interactions
        /// </summary>
        private void mitem_Connect_Clicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Menu->File->Connect");
        }

        private void mitem_Upload_Clicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Menu->File->Upload");
        }

        private void mitem_Exit_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mitem_Properties_Clicked(object sender, RoutedEventArgs e)
        {
            PropertiesWindow propertiesWindow = new PropertiesWindow();
            propertiesWindow.Show();
        }

        private void mitem_About_Clicked(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
