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
using WinOSD;

namespace WPFDemo
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

        private void Defaults_Click(object sender, RoutedEventArgs e)
        {
            WinOSD.OSD.Display("THIS IS USING THE DEFAULTS");

        }

        private void Preset1_Click(object sender, RoutedEventArgs e)
        {
            WinOSD.OSD.Display(
            text:"SHOWING OSD: Preset1!",
            x: 20, y: 45,   //Location
            opacity: 255,   //Opacity
            displayTime: 3000,   //Display time in ms
            animation: AnimateMode.ExpandCollapse, //Display animation
            animationTime: 200 //Animation time
            );


        }

        
    }
}
