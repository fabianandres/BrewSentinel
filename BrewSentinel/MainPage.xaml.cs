using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BrewSentinel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Visibility = Visibility.Visible;
            this.MainFrame.Navigate(typeof(Start));
        }

        public void HamburgerButton_Click(object sender, RoutedEventArgs args)
        {
            this.MySplitView.IsPaneOpen = !this.MySplitView.IsPaneOpen;
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Start));

        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Recieps));
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Settings));
        }

        private void MenuCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
