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

namespace SerialKiller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set Theme per Preference
            if(Properties.Settings.Default.Mode.ToString() == "dark")
            {
                AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, AdonisUI.ResourceLocator.DarkColorScheme);
            } else
            {
                AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, AdonisUI.ResourceLocator.LightColorScheme);
            }
        }

        private void ChangeTheme(bool oldValue)
        {
            //AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, oldValue ? AdonisUI.ResourceLocator.LightColorScheme : AdonisUI.ResourceLocator.DarkColorScheme);
        }

        /// <summary>
        /// Connection Functions
        /// </summary>
        private void btn_Conect_Clicked(object sender, RoutedEventArgs e)
        {
            // Variables
            string port = txt_Port.Text;
            SerialPort conn = new SerialPort();

            // Check for Empty Port String
            if(port == "")
            {
                lblStatus.Text = "No port designated.";
            }

            // Try to Connect to Port (Hard Coded for now)
            conn.PortName = "COM3"; // "COM3" String
            conn.BaudRate = 9600; // 9600 Int32
            conn.Parity = Parity.None; // No Parity Enum
            conn.StopBits = StopBits.One;
            conn.DataBits = 8;
            conn.Handshake = Handshake.None;
            conn.RtsEnable = true;

            try
            {
                conn.Open();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine(conn.ReadLine());

            conn.Close();
            

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
