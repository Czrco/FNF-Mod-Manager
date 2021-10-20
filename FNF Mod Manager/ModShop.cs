using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace FNF_Mod_Manager
{
    public partial class ModShop : Form
    {
        string daFile = "";
        string webData = "";
        string daTheme = "";
        public ModShop()
        {
            // lots of init stuffs go here
            InitializeComponent();
            this.FormClosing += ModManager_FormClosing;
            listBox1.BackColor = this.BackColor;
            // download mods then close
            WebClient wc = new WebClient();
            webData = wc.DownloadString("https://pastebin.com/raw/SSmHhg9F");
            File.WriteAllText("./links/list/modList", webData);
            System.IO.StreamReader sr = new System.IO.StreamReader("./links/list/modList");
            while (!sr.EndOfStream)
            {
                listBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();

            //download mod links then close
            WebClient wc2 = new WebClient();
            webData = wc2.DownloadString("https://pastebin.com/raw/TzEyyKy6");
            File.WriteAllText("./links/links", webData);

            //init option
            initFileOptions();
        }

        private void ModManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            var s = new StartForm();
            s.Show();
            this.Hide();
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(51,51,51);
            menuStrip1.BackColor = Color.FromArgb(31, 31, 31);
            toolStripMenuItem1.ForeColor = Color.FromArgb(151, 151, 151);
            musicPlayerToolStripMenuItem.ForeColor = Color.FromArgb(151, 151, 151);
            fileFormatToolStripMenuItem.ForeColor = Color.FromArgb(151, 151, 151);
            listBox1.BackColor = this.BackColor;
            listBox1.ForeColor = Color.FromArgb(151, 151, 151);
            WriteToLine("./config/options", "dark", 2);
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
            menuStrip1.BackColor = this.BackColor;
            toolStripMenuItem1.ForeColor = Color.FromArgb(0, 0, 0);
            musicPlayerToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            fileFormatToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
            listBox1.BackColor = this.BackColor;
            listBox1.ForeColor = Color.FromArgb(0, 0, 0);
            WriteToLine("./config/options", "light", 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var m = new Form1();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Directory.Exists("./mods/" + listBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("You already have this mod.", "Mod already installed");
            }
            else
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        var daLink = GetLine(@"./links/links", Convert.ToInt32(listBox1.SelectedIndex.ToString()));
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        wc.DownloadFileAsync(
                            // Param1 = Link of file
                            new System.Uri(daLink),
                            // Param2 = Path to save
                            "./mods/" + listBox1.SelectedItem.ToString() + daFile
                        );
                        button2.Text = "Downloading...";
                        Console.WriteLine(daLink);
                        Console.WriteLine(Convert.ToInt32(listBox1.SelectedIndex.ToString()));
                    }
                }
                catch (Exception exc)
                {
                    string path = @"./FATAL.txt";

                    using (StreamWriter sw = File.CreateText(path))
                        sw.Write(exc);
                    Console.Write(exc);
                    MessageBox.Show("A fatal error occured! Report this to Czrco and send the file called FATAL.txt in your path to him.\nIf you want a challenge, try to solve it yourself... ;)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                return sr.ReadLine();
            }
        }

        private void WriteToLine(string fileName, string contents, int line)
        {
            try
            {
                using (var sr = new StreamWriter(fileName))
                {
                    for (int i = 0; i < line; i++)
                        sr.WriteLine(contents);
                }
            }
            catch (Exception ex)
            {
                string path = @"./FATAL.ERR";

                using (StreamWriter sw = File.CreateText(path))
                    sw.Write(ex);

                MessageBox.Show("A fatal error occured! The error has been automatically reported and will be fixed in the next few days. \nSorry for the inconvenience 😅", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            System.IO.Directory.CreateDirectory("./mods/" + listBox1.SelectedItem.ToString());
            button2.Text = "Extracting...";
            var resultPath = "./mods/" + listBox1.SelectedItem.ToString();
            ZipFile.ExtractToDirectory("./mods/" + listBox1.SelectedItem.ToString() + daFile, resultPath);
            button2.Text = "Download Selected Mod";
            MessageBox.Show("Successfully downloaded " + listBox1.SelectedItem.ToString() + "! Now you can open it and play the mod when you want.");
            string[] alreadydownloaded = new string[] { listBox1.SelectedItem.ToString() };
            WriteToLine("./alreadyDownloaded", listBox1.SelectedItem.ToString(), 1);
            File.Delete("./mods/" + listBox1.SelectedItem.ToString() + daFile);
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void targzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("./config/file", ".tar.gz");
            initFileOptions();
        }

        private void zipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("./config/file", ".zip");
            initFileOptions();
        }

        private void rarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("./config/file", ".rar");
            initFileOptions();
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText("./config/file", ".7z");
            initFileOptions();
        }

        public void initFileOptions()
        {
            daFile = File.ReadAllText("./config/file");
            daTheme = File.ReadAllText("./config/theme");
            setTheme();
        }

        public void setTheme()
        {
            string[] dark = new string[] { "dark" };
            if (GetLine(@"./config/theme", 1) == "dark")
            {
                Console.WriteLine("dark");
                this.BackColor = Color.FromArgb(51, 51, 51);
                menuStrip1.BackColor = Color.FromArgb(31, 31, 31);
                toolStripMenuItem1.ForeColor = Color.FromArgb(151, 151, 151);
                musicPlayerToolStripMenuItem.ForeColor = Color.FromArgb(151, 151, 151);
                fileFormatToolStripMenuItem.ForeColor = Color.FromArgb(151, 151, 151);
                listBox1.BackColor = this.BackColor;
                listBox1.ForeColor = Color.FromArgb(151, 151, 151);
            } else
            {
                Console.WriteLine("light");
                this.BackColor = Color.FromArgb(255, 255, 255);
                menuStrip1.BackColor = this.BackColor;
                toolStripMenuItem1.ForeColor = Color.FromArgb(0, 0, 0);
                musicPlayerToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
                fileFormatToolStripMenuItem.ForeColor = Color.FromArgb(0, 0, 0);
                listBox1.BackColor = this.BackColor;
                listBox1.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
