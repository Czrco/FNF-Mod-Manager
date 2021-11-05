using Windows;
using Scripts;
using System.Threading;
using System.Windows;
using System;

namespace Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            new DownloadManager().CheckForDownload();
            Debug_Box.Text = new Utilities().ReadFile("./settings/log.log");

        }

        private void ModShop(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ModShop shop = new ModShop();
            shop.Show();
        }

        private void ModShelf(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ModShelf shop = new ModShelf();
            shop.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(69); // FUNNY
        }
    }
}