using FNF_Mod_Manager.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNF_Mod_Manager
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            ProtocolMaker maker = new ProtocolMaker();
            maker.MakeProtocol();
            this.FormClosing += StartForm_FormClosing;
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var m = new ModShop();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
