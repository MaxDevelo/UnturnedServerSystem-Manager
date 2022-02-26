using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalOrganiserControls.Unturned3.Installer;
using System.IO;
using UniversalOrganiserControls.Unturned3;
using UniversalOrganiserControls.Unturned3.UCB;
using UniversalOrganiserControls.Unturned3.RocketMod;
using UniversalOrganiserControls.Unturned3.Workshop;
using System.Net;

namespace uso_cli
{
    public static partial class CommandCollection
    {
        public static Dictionary<string, CommandDelegation> commands = new Dictionary<string, CommandDelegation>();
        public static Dictionary<string, string> commandDescriptions = new Dictionary<string, string>();
        public static Dictionary<string, string> commandUsages = new Dictionary<string, string>();

        public delegate void CommandDelegation(params Command.Argument[] args);


        public static void RegisterCommands()
        {
            RegisterCommand("help", Help, "A help command.", "", "?");
            RegisterCommand("close", Close, "Closes the CLI tool.", "", "exit");
            RegisterCommand("ping", Ping, "Playing ping pong.");

            RegisterCommand("varlist", ListVars, "Shows a list of current registred variables.", "", "listvar");
            RegisterCommand("varset", SetVar, "Sets a variable used by the CLI.", "varset(id=value)", "setvar");
            RegisterCommand("updateengine", UpdateEngine, "Updates the Unturned server files", "updateEngine(validate)", "updateserver");
            RegisterCommand("runserver", RunServer, "Launches an Unturned server", "runserver(serverid)", "startserver");
            RegisterCommand("updaterocketmod", InstallRocketMod, "Installs or updates RocketMod.", "updaterocketmod(validate)", "installrocketmod");

            RegisterCommand("updatecli", UpdateCLI, "Updates this tool", "");

            RegisterCommand("addmod", AddWorkshopMod,"Installs a steam workshop mod","addmod(serverid,modid OR modlink)");
            RegisterCommand("removemod", RemoveWorkshopMod, "Removes a steam workshop mod", "removemod(serverid, modid)");
            RegisterCommand("listmods", ListWorkshopMods, "Lists all installed steam workshop mods", "listmods(serverid)", "modlist");
            RegisterCommand("script", ExecuteScript, "Runs all commands defined in a script file", "script(file)");

            RegisterCommand("clear", (Command.Argument[] args) => { Console.Clear(); }, "Clears the console output", "clear", "cls");
            RegisterCommand("echo", Echo, "Simple echo command", "echo(text)");
        }

        public static void RegisterDevCommands()
        {
            Program.Print("Adding dev commands..", ConsoleColor.Magenta, "DEV MODE", ConsoleColor.Yellow);

            RegisterCommand("pause", Pause, "Lets the CLI wait for user input");


            RegisterCommand("runucbserver", RunUCBServer, "!!EXPERIMENTAL FEATURE!! Starts the Unturned Console Bridge Server", "runucbserver(port)");
            RegisterCommand("stopucbserver", StopUCBServer, "!!EXPERIMENTAL FEATURE!! Stops the Unturned Console Bridge Server");
            RegisterCommand("ucbcmd", UCBCommand, "Lets the CLI wait for user input","ucbcmd(serverid,cmd)");
            RegisterCommand("ucbinfo", UCBStatus, "!!EXPERIMENTAL FEATURE!! Shows some information about the Unturned Console Bridge Server");
        }

        private static string GetArgument(string id, params Command.Argument[] args)
        {
            foreach(Command.Argument arg in args)
            {
               
                if (arg.id.ToLower() == id.ToLower())
                {
                    Program.VARS[arg.id] = arg.value;
                    return arg.value;
                }
            }


            if (Program.VARS.ContainsKey(id)) return Program.VARS[id];

            return null;
        }


        public static void RegisterCommand(string command, CommandDelegation del, string description = "", string usage = "", params string[] aliases)
        {
            commands.Add(command, del);
            commandDescriptions.Add(command, description);
            commandUsages.Add(command, usage);

            foreach (string alias in aliases)
            {
                commands.Add(alias, del);
                commandUsages.Add(alias, usage);
                commandDescriptions.Add(alias, description);
            }
        }

        public static void Echo(params Command.Argument[] args)
        {
            foreach(Command.Argument arg in args)
            {
                if (arg.id.Equals("text"))
                {
                    Program.Print(arg.value, ConsoleColor.White, "ECHO", ConsoleColor.Cyan);
                }
            }
        }

        public static void Close(params Command.Argument[] args)
        {
            Program.RequestExit = true;
        }

        public static void Ping(params Command.Argument[] args)
        {
            uint count = 1;
            foreach(Command.Argument arg in args)
            {
                if (arg.id.Equals("count"))
                {
                    try
                    {
                        count = Convert.ToUInt32(arg.value);
                    }
                    catch (Exception) { }
                }
            }
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("Pong!");
            }
        }


        public static void UpdateEngine(params Command.Argument[] args)
        {

            DirectoryInfo enginePath = Program.enginePath;


            U3OnlineInstaller installer = new U3OnlineInstaller(enginePath);
            foreach(Command.Argument arg in args)
            {
                if (arg.id.Equals("validate"))
                {
                    installer.Validate = Convert.ToBoolean(arg.value);
                }
                else if (arg.id.Equals("fresh"))
                {
                    installer.FreshInstall = Convert.ToBoolean(arg.value);
                }
                else if (arg.id.Equals("keepServers"))
                {
                   installer.KeepServersOnFreshInstall = Convert.ToBoolean(arg.value);
                }
            }
            installer.InstallationProgressChanged += Installer_InstallationProgressChanged;
            installer.UpdateInterval = 1000;

            installer.Update().Wait();
        }

        private static void Installer_InstallationProgressChanged(object sender, UniversalOrganiserControls.Unturned3.U3OnlineInstallationProgressArgs e)
        {
            switch (e.state)
            {
                case UniversalOrganiserControls.Unturned3.U3InstallationState.SearchingUpdates:
                    Program.Print(string.Format("Searching for updates.."),ConsoleColor.White,"U3Installer",ConsoleColor.Cyan,true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.DeletingOldFiles:
                    Program.Print(string.Format("Deleting old files.."), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.CalculatingFileDifferences:
                    Program.Print(string.Format("Calculating differences.."), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.Downloading:
                    Program.Print(string.Format("Downloading {0}% ..", e.percentage), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.Ok:
                    Program.Print(string.Format("OK"), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.FailedSome:
                    Program.Print(string.Format("Failed: Not able to update all files"), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.FailedInternet:
                    Program.Print(string.Format("Failed: internet"), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.FailedUnknown:
                    Program.Print(string.Format("Failed unknown"), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.FailedInvalidResponse:
                    Program.Print(string.Format("Failed: invalid response"), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.PausedServerBusy:
                    Program.Print(string.Format("Paused while server is busy.."), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                case UniversalOrganiserControls.Unturned3.U3InstallationState.AbortedByCall:
                    Program.Print(string.Format("Aborted by call."), ConsoleColor.White, "U3Installer", ConsoleColor.Cyan, true);
                    break;
                default:
                    break;
            }
        }

        public static void RunServer(params Command.Argument[] args)
        {
            string sid = GetArgument("serverid", args);


            U3Server server = Program.FindServer(sid);
            if (server == null)
            {
                U3ServerEngineSettings settings = new U3ServerEngineSettings(new FileInfo(Program.enginePath.FullName + "\\Unturned.exe"), sid);
                server = new U3Server(settings);
                Program.SERVERS.Add(server);
            }

            if (Program.UCB != null)
            {
                server.UCBManager = Program.UCB;
            }

            Program.Print(string.Format("Starting {0} ..", sid), ConsoleColor.White);
            U3ServerStartResult result = server.Start();
            Console.WriteLine("ServerStartResponse: " + result.ToString(),ConsoleColor.White);
        }


        public static void SetVar(params Command.Argument[] args)
        {
            foreach(Command.Argument arg in args)
            {
                Program.VAR(arg.id.ToLower(), arg.value);
                Console.WriteLine("set variable " + arg.id + " to " + arg.value);
            }
        }

        

        public static void ListVars(params Command.Argument[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (string id in Program.VARS.Keys)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("ID: " + id + "    ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Value: " + Program.VARS[id]);
                Console.WriteLine("");

            }
            Console.ForegroundColor = ConsoleColor.White;
        }



        public static void Help(params Command.Argument[] args)
        {
            Program.Print("Commands have the following syntax: cmd(argumentId=argumentValue)", ConsoleColor.Yellow);

            Program.Print("Here is a list of available commands:",ConsoleColor.Yellow);
            foreach (string command in commands.Keys)
            {
                if (commandDescriptions.ContainsKey(command))
                {
                    Program.Print(string.Format("Description: {0} Usage: {1}", commandDescriptions[command], commandUsages[command] == "" ? command : commandUsages[command]), ConsoleColor.White, command, ConsoleColor.Cyan);
                }
                else
                {
                    Program.Print("(no description available)", ConsoleColor.White, command, ConsoleColor.Cyan);
                }
            }
        }


        public static void InstallRocketMod(params Command.Argument[] args)
        {
            bool validate = false;
            foreach (Command.Argument arg in args)
            {
                if (arg.id.ToLower().Equals("validate")) validate = Convert.ToBoolean(arg.value.ToLower());
            }

            RocketModInstaller installer = new RocketModInstaller(Program.enginePath);

            Program.Print("Searching for RocketMod Updates..", ConsoleColor.White, "RocketMod", ConsoleColor.Cyan);
            string serverVersion = installer.GetServerVersion().Result;
            bool updateAvail = installer.IsUpdateAvailable().Result;

            Program.Print("Current RocketMod Version: " + installer.LocalVersion, ConsoleColor.White, "RocketMod", ConsoleColor.Cyan);
            Program.Print("Newest RocketMod Version: " + serverVersion, ConsoleColor.White, "RocketMod", ConsoleColor.Cyan);

            if (updateAvail | validate)
            {
                Program.Print("Updating RocketMod.." + installer.LocalVersion, ConsoleColor.White, "RocketMod", ConsoleColor.Cyan);
                RocketModInstallationCompletedType r = installer.Install(validate).Result;
                Program.Print("Update finished: " + r.ToString(), ConsoleColor.White, "RocketMod", ConsoleColor.Cyan);

            }
            else
            {
                Program.Print("No updates found.", ConsoleColor.White, "RocketMod", ConsoleColor.Cyan);
            }          
        }


        public static void UpdateCLI(params Command.Argument[] args)
        {
            string downloadUrl = "http://update.unturned-server-organiser.com/usocli.exe";
            string versionUrl = "http://update.unturned-server-organiser.com/CLIVersion.php";

            WebClient client = new WebClient();

            Program.Print("Searching for updates..", ConsoleColor.White, "CLI-Updater", ConsoleColor.Green);
            string newest_hash = client.DownloadString(new Uri(versionUrl));
            string current_hash = Program.CalculateMD5(AppDomain.CurrentDomain.FriendlyName);


            if (!current_hash.Equals(newest_hash))
            {
                Program.Print("Downloading update...", ConsoleColor.White, "CLI-Updater", ConsoleColor.Green);
                client.DownloadFile(new Uri(downloadUrl), Environment.CurrentDirectory + "\\_usocli.exe");
                Program.Print("Download complete!", ConsoleColor.White, "CLI-Updater", ConsoleColor.Green);
                System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\_usocli.exe");
                Environment.Exit(0);
            }
            else
            {
                Program.Print("No updates found.", ConsoleColor.White, "CLI-Updater",ConsoleColor.Green);
            }
        }


        public static void AddWorkshopMod(params Command.Argument[] args)
        {
            string sid = GetArgument("serverid", args);
            List<string> modids = new List<string>();
            List<string> modlinks = new List<string>();


            foreach(Command.Argument arg in args)
            {
                if (arg.id == "modid") modids.Add(arg.value);
                if (arg.id == "modlink") modlinks.Add(arg.value);
            }

            if (string.IsNullOrEmpty(sid))
            {
                Program.Print("Please pass the command argument \"serverid\".");
                return;
            }

      
            U3Server server = new U3Server(new U3ServerEngineSettings(new FileInfo(Program.enginePath.FullName + "\\Unturned.exe"), sid));


            if (modids.Count == 0 && modlinks.Count == 0)
            {
                Program.Print("Please pass the command argument \"modid\" or \"modlink\".",ConsoleColor.Yellow,"SteamWorkshop",ConsoleColor.Cyan);
                return;
            }
            else
            {
               
                foreach(string modlink in modlinks)
                {
                    modids.AddRange(U3WorkshopMod.getIDFromWorkshopSite(modlink));
                }

                foreach (string id in modids)
                {
                    server.WorkshopAutoUpdaterConfig.Add(id);
                }
            }
            Program.Print("Mod(s) added!", ConsoleColor.Green, "SteamWorkshop", ConsoleColor.Cyan);
        }


        public static void RemoveWorkshopMod(params Command.Argument[] args)
        {
            string sid = GetArgument("serverid",args);
            string modid = null;
            string modlink = null;

            foreach (Command.Argument arg in args)
            {
                if (arg.id == "modid") modid = arg.value;
                if (arg.id == "modlink") modlink = arg.value;
            }

            if (string.IsNullOrEmpty(sid))
            {
                Program.Print("Please pass the command argument \"serverid\".");
                return;
            }


            U3Server server = new U3Server(new U3ServerEngineSettings(new FileInfo(Program.enginePath.FullName + "\\Unturned.exe"), sid));


            if (string.IsNullOrEmpty(modid) && string.IsNullOrEmpty(modlink))
            {
                Program.Print("Please pass the command argument \"modid\" or \"modlink\".", ConsoleColor.Yellow, "SteamWorkshop", ConsoleColor.Cyan);
                return;
            }
            else
            {
                List<string> ids = new List<string>();
                if (!string.IsNullOrEmpty(modlink))
                {

                    ids.AddRange(U3WorkshopMod.getIDFromWorkshopSite(modlink));
                }

                if (!string.IsNullOrEmpty(modid))
                {
                    if (!ids.Contains(modid)) ids.Add(modid);
                }

                foreach (string id in ids)
                {
                    server.WorkshopAutoUpdaterConfig.Remove(id,true);
                }

            }
            Program.Print("Mod(s) removed!", ConsoleColor.Green, "SteamWorkshop", ConsoleColor.Cyan);
        }

        public static void ListWorkshopMods(params Command.Argument[] args)
        {
            string sid = GetArgument("serverid", args);

            if (string.IsNullOrEmpty(sid))
            {
                Program.Print("Please pass the command argument \"serverid\".");
                return;
            }


            U3Server server = new U3Server(new U3ServerEngineSettings(new FileInfo(Program.enginePath.FullName + "\\Unturned.exe"), sid));

            Program.Print(string.Format("Searching mods for {0} ..",sid), ConsoleColor.White, "SteamWorkshop", ConsoleColor.Cyan);


            string output = string.Format("{0} mod(s) registered in UpdaterConfig.\n", server.WorkshopAutoUpdaterConfig.RegistredMods.Count);
            output += string.Format("{0} mod(s) installed.\n", server.WorkshopAutoUpdaterConfig.InstalledMods.ToArray().Length);

            output += "Registered in UpdaterConfig: {";
            string title;
            foreach(string modid in server.WorkshopAutoUpdaterConfig.RegistredMods)
            {
                title = U3WorkshopMod.getModTitle(modid);
                output += !string.IsNullOrEmpty(title) ? string.Format("{0}({1}),", modid, title) : modid + ",";
            }
            if (output.EndsWith(",")) output = output.Remove(output.Length - 1,1);
            output += "}\n";

            output += "Installed maps: {";
            foreach (U3WorkshopMod mod in server.WorkshopAutoUpdaterConfig.InstalledMapMods)
            {
                output += !string.IsNullOrEmpty(mod.Title) ? string.Format("{0}({1}),", mod.ID, mod.Title) + "," : mod.ID + ",";
            }
            if (output.EndsWith(",")) output = output.Remove(output.Length - 1, 1);
            output += "}\n";

            output += "Installed object mods: {";
            foreach (U3WorkshopMod mod in server.WorkshopAutoUpdaterConfig.InstalledContentMods)
            {
                output += !string.IsNullOrEmpty(mod.Title) ? string.Format("{0}({1}),",mod.ID,mod.Title) : mod.ID + ",";
            }
            if (output.EndsWith(",")) output = output.Remove(output.Length - 1, 1);
            output += "}\n";

            Program.Print(output, ConsoleColor.White);
                 
        }


        public static void ExecuteScript(params Command.Argument[] args)
        {
            string scriptFilePath = GetArgument("file",args);
            if (string.IsNullOrEmpty(scriptFilePath))
            {
                Program.Print("Please pass the argument \"file\"", ConsoleColor.Red);
                return;
            }
            FileInfo scriptFile = new FileInfo(scriptFilePath);
            if (scriptFile.Exists)
            {
                Program.Print("Executing script..", ConsoleColor.DarkGray);
                string[] commands = File.ReadAllLines(scriptFilePath);
                foreach(string command in commands)
                {
                    Program.Print(command, ConsoleColor.White, "Script", ConsoleColor.Cyan);
                    Program.ExecuteCommand(command).Wait();
                }
            }
            else
            {
                Program.Print("Script file not found!", ConsoleColor.Red);
            }

        }


        public static void UCBStatus(params Command.Argument[] args)
        {
            if (Program.UCB != null)
            {

                Program.Print("The server is running. Here some more information:", ConsoleColor.White, "UCB", ConsoleColor.Cyan);

                string output = "";
                output += "Known Unturned servers: {";
                foreach (U3Server s in Program.UCB.AvailableServers)
                {
                    output += s.ServerInformation.ServerID + ",";
                }
                if (output.EndsWith(",")) output = output.Remove(output.Length - 1, 1);
                output += "}\n";

                output += "Actually connected Unturned servers: {";
                foreach (U3Server s in Program.UCB.IdentifiedServers.Values)
                {
                    output += s.ServerInformation.ServerID +  ",";
                }

                if (output.EndsWith(",")) output = output.Remove(output.Length - 1, 1);
                output += "}\n";


                Program.Print(output, ConsoleColor.White);
            }
            else
            {
                Program.Print("The UCB server is not running!", ConsoleColor.Green, "UCB", ConsoleColor.Cyan);
            }
        }

        public static void StopUCBServer(params Command.Argument[] args)
        {
            if (Program.UCB != null)
            {
                Program.Print("Stopping server..", ConsoleColor.White, "UCB", ConsoleColor.Cyan);
                Program.UCB.Shutdown();
                Program.UCB = null;
                Program.Print("UCB Server stopped.", ConsoleColor.White, "UCB", ConsoleColor.Cyan);
            }
            else
            {
                Program.Print("There is no UCB server running!", ConsoleColor.White, "UCB", ConsoleColor.Cyan);
            }
        }

        public static void RunUCBServer(params Command.Argument[] args)
        {
            if (Program.UCB == null)
            {
                int port = 0;
                try
                {
                    port = Convert.ToInt32(GetArgument("ucbport", args));
                }
                catch (Exception) { }

                if (port == 0)
                {
                    Program.Print("Please pass the argument \"ucbport\"", ConsoleColor.Red);
                    return;
                }

                Program.Print(string.Format("Starting UCB Server on port {0} ..", port), ConsoleColor.White, "UCB", ConsoleColor.Cyan);

                Program.UCB = new UCBManager(port);
                
                foreach(DirectoryInfo serverDir in new DirectoryInfo(Program.enginePath.FullName + "\\Servers\\").GetDirectories())
                {
                    U3Server s = Program.FindServer(serverDir.Name);                
                    if (s == null)
                    {
                        s = new U3Server(new U3ServerEngineSettings(new FileInfo(Program.enginePath.FullName + "\\Unturned.exe"), serverDir.Name));
                        Program.SERVERS.Add(s);
                    }
                    s.UCBManager = Program.UCB;
                }

              
                
                Program.UCB.ServerIdentified += UCB_ServerIdentified;
                Program.UCB.ServerDisconnected += UCB_ServerDisconnected;
               


                Program.Print(string.Format("UCB server started!",port), ConsoleColor.White, "UCB", ConsoleColor.Cyan);
            }
            else
            {
                Program.Print("The UCB Server is already running!", ConsoleColor.White, "UCB", ConsoleColor.Cyan);
            }

            
        }

        private static void UCB_ServerDisconnected(object sender, U3Server e)
        {
            Program.Print(string.Format("Server disconnected from UCB: {0}", e.ServerInformation.ServerID), ConsoleColor.White, "UCB", ConsoleColor.Cyan);
        }

        private static void UCB_ServerIdentified(object sender, U3Server e)
        {
            Program.Print(string.Format("Server connected to UCB: {0}", e.ServerInformation.ServerID),ConsoleColor.White,"UCB",ConsoleColor.Cyan);
        }


        public static void UCBCommand(params Command.Argument[] args)
        {
            string serverid = GetArgument("serverid",args);
            string cmd = GetArgument("cmd",args);
            U3Server server = Program.SERVERS.First((U3Server s) => (s.ServerInformation.ServerID.Equals(serverid)));
            server.SendCommand(cmd);
        }

        public static void Pause(params Command.Argument[] args)
        {
            int time = Convert.ToInt32(GetArgument("time",args));
            if (time > 0)
            {
                Program.Print("Waiting " + time + " seconds before continue..");
                Task.Delay(1000 * time).Wait();
            }
            else
            {
                Console.Write("Press any key to continue..");
                Console.ReadKey();
                Console.WriteLine("");
            }

        }

    }
}
