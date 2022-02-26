using System;
using System.IO;
using System.Windows.Forms;
using Unturned_Server_System.Confiduration;
using Unturned_Server_System.Constants;
using Unturned_Server_System.Configuration;
using Unturned_Server_System.SteamCMD_Manager;

namespace Unturned_Server_System.Updating
{
    internal static class Updater
    {
        /// <summary>
        ///     Installs the latest version of Unturned.
        /// </summary>
        public static void UpdateUnturned()
        {
            SteamCmd.RunCommand($"+force_install_dir \"{ServerPath.Value}\" +app_update 1110390 +exit");

            var installedVersions = LocalVersions.Load();
            installedVersions.LastUnturnedUpdate = DateTime.Now;
            installedVersions.SaveJson();
        }

        /// <summary>
        ///     Validates and Installs the latest version of Unturned.
        /// </summary>
        public static void ValidateUnturned()
        {
            SteamCmd.RunCommand(
                $"+force_install_dir \"{ServerPath.Value}\" +app_update 1110390 validate +exit");

            var installedVersions = LocalVersions.Load();
            installedVersions.LastUnturnedUpdate = DateTime.Now;
            installedVersions.SaveJson();
        }

        /// <summary>
        ///     Downloads and installs RocketMod.
        /// </summary>
        public static void UpdateRocket()
        {
            Directory.Delete(ServerPath.Value + @"\Modules");
            var tempZip = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            
            if (!FileActions.Download(RocketDownloadUrl.Value, tempZip))
            {
                MessageBox.Show(
                    "An error occured during download. Please verify that you can access github.",
                    "Rocketmod download failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FileActions.ExtractZip(tempZip, ServerPath.Value);

            Directory.Move(ServerPath.Value + @"\Modules-main", ServerPath.Value + @"\Modules");
        }

        /// <summary>
        ///     Downloads and installs RocketMod + Unturned.
        /// </summary>
        public static void UpdateAll()
        {
            UpdateUnturned();
            UpdateRocket();
        }
    }
}