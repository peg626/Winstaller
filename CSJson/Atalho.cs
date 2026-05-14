using System.Diagnostics;
using System.IO;

namespace CSJson.Atalho
{
    public class DesktopAtalho
    {
        public DesktopAtalho(string atpath, string awdir, string ades, string aname)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string shortcutPath = Path.Combine(desktop, aname + ".lnk");

            string script = $@"
$WshShell = New-Object -comObject WScript.Shell
$Shortcut = $WshShell.CreateShortcut('{shortcutPath}')
$Shortcut.TargetPath = '{Path.GetFullPath(atpath)}'
$Shortcut.WorkingDirectory = '{awdir}'
$Shortcut.Description = '{ades}'
$Shortcut.Save()
";

            Process.Start(new ProcessStartInfo()
            {
                FileName = "powershell",
                Arguments = $"-ExecutionPolicy Bypass -Command \"{script}\"",
                CreateNoWindow = true,
                UseShellExecute = false
            });
        }
    }
}