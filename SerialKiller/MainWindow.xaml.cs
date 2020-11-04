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
