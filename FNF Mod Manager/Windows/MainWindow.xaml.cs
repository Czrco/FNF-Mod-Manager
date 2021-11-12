using Windows;
using Scripts;
using System.Threading;
using System.Windows;
using System;
using System.Diagnostics;
using System.IO;

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
            var realVersion = "0.02-dev-a-bugfix";
            this.Title += " " + realVersion + "]";
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
            ModShelf shelf = new ModShelf();
            shelf.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Updates_Click(object sender, RoutedEventArgs e)
        {
            var version = new Utilities().StringDownload("https://czrcos-databasee.000webhostapp.com/fnf%20mod%20manager/update-resources/version");
            var realVersion = "0.02-dev-a-bugfix";
            if (version != realVersion)
            {
                MessageBox.Show("You need an update! Your current version is v" + realVersion + ". The newest version is v" + version + ". Opening Updater...");
                Directory.Move("./Mods/", "../ModBackups");
                File.WriteAllText("../ModBackups/WHAT TO DO WITH THIS FOLDER.txt", "This was auto-generated from FNF Mod Manager." +
                "\nalr so after the move is complete, you just rename this folder to \"Mods\" and plop it in the fnf mod manager folder." +
                "\nhappy funkin!");
                try
                {
                    var PrcInfo = new ProcessStartInfo(@"..\Updater\FNF Mod Manager Updater.exe");
                    PrcInfo.WorkingDirectory = @"..\Updater\";
                    PrcInfo.CreateNoWindow = true;
                    PrcInfo.WindowStyle = ProcessWindowStyle.Normal;
                    Process RealPRC = new System.Diagnostics.Process();
                    RealPRC.StartInfo = PrcInfo;
                    RealPRC.Start();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Oops!");
                }
                Environment.Exit(0);
            } else
            {
                MessageBox.Show("No update is needed.", "You're on the latest version!");
            }
        }
    }
}