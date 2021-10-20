using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace FNF_Mod_Manager.Setup
{
    class ProtocolMaker
    {

        public void MakeProtocol()
        {
            RegistryKey parentKey = Registry.ClassesRoot;
            RegistryKey subKey = parentKey.CreateSubKey("fnfmm");
            subKey.SetValue("(Default)", "URL:fnfmm", RegistryValueKind.String);
            subKey.SetValue("URL Protocol", "", RegistryValueKind.String);
            RegistryKey subKeyShell = subKey.CreateSubKey("shell");
            RegistryKey subKeyOpen = subKeyShell.CreateSubKey("open");
            RegistryKey subKeyCommand = subKeyOpen.CreateSubKey("command");
            subKeyCommand.SetValue("(Default)", Directory.GetCurrentDirectory());
        }
     
    }
}
