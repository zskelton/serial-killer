using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SerialKiller
{
    /// <summary>
    /// Interaction logic for PropertiesWindow.xaml
    /// </summary>
    public partial class PropertiesWindow : Window
    {
        public PropertiesWindow()
        {
            InitializeComponent();
            // Set Toggle Button to Light/Dark Mode in Settings.
            if(Properties.Settings.Default.Mode.ToString() == "dark")
            {
                btn_toggleMode.IsChecked = true;
            } else
            {
                btn_toggleMode.IsChecked = false;
            }
        }

        private void toggle_mode(object sender, RoutedEventArgs e)
        {
            // Variables
            ToggleButton _sender = sender as ToggleButton;

            // Interpret - Checked = Dark, Unchecked = Light
            Console.WriteLine(_sender.IsChecked.ToString()) ;
            if((bool) _sender.IsChecked)
            {
                Properties.Settings.Default.Mode = "dark";
                AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, AdonisUI.ResourceLocator.DarkColorScheme);
            } else
            {
                Properties.Settings.Default.Mode = "light";
                AdonisUI.ResourceLocator.SetColorScheme(Application.Current.Resources, AdonisUI.ResourceLocator.LightColorScheme);
            }

            // Save in Settings
            Properties.Settings.Default.Save();
        }
    }
}
