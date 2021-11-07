using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows;
using Scripts;

namespace Windows
{
    // FILE DESCRIPTION
    // the heart of this whole project! this is the long and sloppy file of mod shop.
    // if you want to add a mod, contact czrco#9998.
    // FILE DESCRIPTION END
    public partial class ModShop : Window
    {
        public ModShop()
        {
            Utilities utils = new Utilities();
            InitializeComponent();
            SetupModShop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProgBar.Visibility = Visibility.Visible;
            DownloadManager manager = new DownloadManager(); 
            Download(new Utilities().GetLine("./settings/links.linkfile", Mod_List.SelectedIndex), Mod_List.SelectedItem.ToString());
        }

        public void Download(string link, string name)
        {
            if(Directory.Exists("./Mods/" + Mod_List.SelectedItem.ToString()))
            {
                MessageBox.Show("bruh tf you have this mod already CHOOSE ANOTHER ONE");
                ProgBar.Visibility = Visibility.Hidden;
                Download_Button.IsEnabled = true;
            } else
            {
                MessageBox.Show("Your mod is downloading. Please wait.");
                Download_Button.IsEnabled = false;
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new Uri(link),
                            // Param2 = Path to save
                            "./Mods/" + name + ".tar.gz"
                        );
                    }
                }
                catch (Exception exc)
                {
                    string pathex = @"./FATAL.txt";

                    using (StreamWriter sw = File.CreateText(pathex))
                        sw.Write(exc);
                    Console.Write(exc);
                    MessageBox.Show("A fatal error occured! Report this to Czrco and send the file called FATAL.txt in your path to him.\nIf you want a challenge, try to solve it yourself... ;)", "Error!");
                    Download_Button.IsEnabled = true;
                    ProgBar.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            new Utilities().WriteLine("./settings/log.log", "You downloaded " + Mod_List.SelectedItem.ToString() + ". " + DateTime.Now);
            ZipFile.ExtractToDirectory("./Mods/" + Mod_List.SelectedItem.ToString() + ".tar.gz", "./Mods/" + Mod_List.SelectedItem.ToString());
            ProgBar.Visibility = Visibility.Hidden;
            MessageBox.Show("Mod downloaded!\n" +
            "If you want to, you can specify the mod's executable and make it easier to play in the future.");
            MessageBox.Show("All you need to do is click OK on this message and link the prompt to the mod exe. It's in .mods/name of mod.");
            var file = new Utilities().FilePrompt("Executable files DUMBASS (.exe)", "*.exe");
            new Utilities().WriteLine("./settings/exe.executables", file.ToString());
            new Utilities().WriteLine("./settings/mods.mods", Mod_List.SelectedItem.ToString());
            MessageBox.Show("Now choose the FOLDER your mod is in.");
            var folder = new Utilities().FolderPrompt();
            new Utilities().WriteLine("./settings/folders.folderfile", folder.ToString());
            MessageBox.Show("Done! You can go back to the main menu and you will find your mod on the mod shelf.");
            Download_Button.IsEnabled = true;
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgBar.Value = e.ProgressPercentage;
        }

        private void SetupModShop()
        {
            string webData = new Utilities().StringDownload("https://czrcos-databasee.000webhostapp.com/fnf%20mod%20manager/names");
            File.WriteAllText("./TEMPMODLIST", webData);
            StreamReader sr = new StreamReader("./TEMPMODLIST");
            while (!sr.EndOfStream)
            {
                Mod_List.Items.Add(sr.ReadLine());
            }
            sr.Close();
            File.Delete("./TEMPMODLIST");

            WebClient wc2 = new WebClient();
            webData = wc2.DownloadString("https://czrcos-databasee.000webhostapp.com/fnf%20mod%20manager/links");
            File.WriteAllText("./settings/links.linkfile", webData);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Update_List_Click(object sender, RoutedEventArgs e)
        {
            Mod_List.Items.Clear();
            Mod_List.Items.Add("Updating...");
            string webData = new Utilities().StringDownload("https://czrcos-databasee.000webhostapp.com/fnf%20mod%20manager/names");
            File.WriteAllText("./TEMPMODLIST", webData);
            StreamReader sr = new StreamReader("./TEMPMODLIST");
            while (!sr.EndOfStream)
            {
                Mod_List.Items.Add(sr.ReadLine());
            }
            sr.Close();
            File.Delete("./TEMPMODLIST");

            WebClient wc2 = new WebClient();
            webData = wc2.DownloadString("https://czrcos-databasee.000webhostapp.com/fnf%20mod%20manager/links");
            File.WriteAllText("./settings/links.linkfile", webData);
            Mod_List.Items.Remove("Updating...");
        }

        private void Privacy_Policy_Click(object sender, RoutedEventArgs e)
        {
            new Utilities().OpenURL("https://czrcos-databasee.000webhostapp.com/fnf%20mod%20manager/privacy-policy.html");
        }
    }
}
