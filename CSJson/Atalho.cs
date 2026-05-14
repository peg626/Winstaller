using System.Diagnostics;
using System.IO;

namespace CSJson.Atalho
{
    public class DesktopAtalho
    {
        // location can be "Desktop" (default) or "StartMenu" (places shortcut in user's Start Menu)
        public DesktopAtalho(string atpath, string awdir, string ades, string aname, string location = "Desktop")
        {
            string folder;
            if (!string.IsNullOrEmpty(location) && location.ToLower().Contains("start"))
            {
                // user's Start Menu folder (Programs)
                folder = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            }
            else
            {
                folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            string shortcutPath = Path.Combine(folder, aname + ".lnk");

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