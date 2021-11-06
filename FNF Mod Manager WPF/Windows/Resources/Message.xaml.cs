using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Windows.Resources
{
    public enum MessageButtons : ushort
    {
        OK = 0,
        YesNo = 1,
        Download = 2
    }
    public partial class Message : Window
    {
        string msg = "";
        MessageButtons btns;
        public Message(string message, MessageButtons buttons)
        {
            InitializeComponent();
            msg = message;
            btns = buttons;
        }
    }
}
