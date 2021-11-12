using Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Windows
{
    /// <summary>
    /// Interaction logic for ModShelf.xaml
    /// </summary>
    public partial class ModShelf : Window
    {
        public ModShelf()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("./settings/mods.mods");
            while (!sr.EndOfStream)
            {
                Exe_List.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        private void Launch_Button_Click(object sender, RoutedEventArgs e)
        {
            var dathing = new Utilities().GetLine("./settings/exe.executables", Exe_List.SelectedIndex);
            var dathingsfolder = new Utilities().GetLine("./settings/folders.folderfile", Exe_List.SelectedIndex);
            new Utilities().LaunchMod(dathingsfolder, dathing);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            CreditsWindow main = new CreditsWindow();
            main.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
