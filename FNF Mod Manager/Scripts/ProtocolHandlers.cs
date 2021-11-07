using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Scripts
{
    class ProtocolHandlers
    {
        public void MakeProtocol()
        {
            RegistryKey parentKey = Registry.ClassesRoot;
            RegistryKey subKey = parentKey.CreateSubKey("fnfmm");
            subKey.SetValue("", "URL:fnfmm", RegistryValueKind.String);
            subKey.SetValue("URL Protocol", "", RegistryValueKind.String);
            RegistryKey subKeyShell = subKey.CreateSubKey("shell");
            RegistryKey subKeyOpen = subKeyShell.CreateSubKey("open");
            RegistryKey subKeyCommand = subKeyOpen.CreateSubKey("command");
            subKeyCommand.SetValue("", "\"" + Directory.GetCurrentDirectory() + @"\FNF Mod Manager.exe" + "\"" + " -download \"%1\"");
        }

        public string ParseProtocol(string line)
        {
            line = line.Replace("fnfmm:", "");
            return line;
        }
    }
}
