using System.IO;
using System.Runtime.InteropServices;
using Unturned_Server_System.Confiduration;

namespace Unturned_Server_System.Constants
{
    internal static class ServerPath
    {
        public static string Value => RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
            ? Installation.Load().InstallationPath
            : Path.Combine(Installation.Load().InstallationPath, "Server");
    }
}