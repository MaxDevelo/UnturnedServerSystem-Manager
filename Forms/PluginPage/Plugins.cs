using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unturned_Server_System.Configuration;
using Unturned_Server_System.Constants;
using System.IO.Compression;
namespace Unturned_Server_System.Forms.PluginPage
{
    public partial class Plugins : Form
    {
        private readonly string _server;
        private string _itemId = "";
        public Plugins(string serverPath)
        {
            InitializeComponent();
            _server = serverPath;
        }

        private void Plugins_Load(object sender, EventArgs e)
        {
            LoadTheme();

        }
        private void LoadInstalled()
        {
            AlreadyInstalled.Items.Clear();
            var pluginLocation = Path.Combine(_server, "Rocket", "Plugins");
            FileActions.VerifyPath(pluginLocation, true);

            var folder = new DirectoryInfo(pluginLocation);
            var content = folder.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            foreach (var file in content)
                AlreadyInstalled.Items.Add(file.Name.Substring(0, file.Name.Length - 4));

            if (AlreadyInstalled.Items.Count == 0)
            {
                Delete.Enabled = false;
                DeleteAll.Enabled = false;
                Configuration.Enabled = false;
                _itemId = "";
            }
            else
            {
                AlreadyInstalled.SelectedIndex = 0;
                Delete.Enabled = true;
                DeleteAll.Enabled = true;
                Configuration.Enabled = true;
            }
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.ForeColor = Color.White;
                }
            }
        }

        private void AlreadyInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlreadyInstalled.SelectedItem != null)
            {
                Delete.Enabled = true;
                Configuration.Enabled = true;
                _itemId = (string)AlreadyInstalled.SelectedItem;
            }
            else
            {
                Delete.Enabled = false;
                Configuration.Enabled = true;
                _itemId = "";
            }
        }

        private void Install_Click(object sender, EventArgs e)
        {
            Hide();
            var pluginLocation = Path.Combine(_server, "Rocket", "Plugins");
            var librariesLocation = Path.Combine(_server, "Rocket", "Libraries");
            var moduleLocation = Path.Combine(ServerPath.Value, "Modules");

            var tempName = Path.GetTempFileName();
            var tempLocation = Path.Combine(Path.GetTempPath(), tempName.Substring(0, tempName.Length - 4));

            var result = OpenZip.ShowDialog();
            if (result == DialogResult.OK)
            {
                var stream = (FileStream)OpenZip.OpenFile();
                FileActions.ExtractZip(stream.Name, tempLocation);

                var tempLibraries = Path.Combine(tempLocation, "Libraries");
                if (FileActions.VerifyPath(tempLibraries, false))
                {
                    var folder = new DirectoryInfo(tempLibraries);
                    var content = folder.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
                    foreach (var file in content)
                    {
                        var dest = Path.Combine(librariesLocation, file.Name);

                        if (File.Exists(dest))
                            File.Delete(dest);

                        FileActions.VerifyFilePath(dest, true);
                        file.MoveTo(dest);
                    }
                }

                var tempPlugins = Path.Combine(tempLocation, "Plugins");
                if (FileActions.VerifyPath(tempPlugins, false))
                {
                    var folder = new DirectoryInfo(tempPlugins);
                    var content = folder.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
                    foreach (var file in content)
                    {
                        var dest = Path.Combine(pluginLocation, file.Name);

                        if (File.Exists(dest))
                            File.Delete(dest);

                        FileActions.VerifyFilePath(dest, true);
                        file.MoveTo(dest);
                    }
                }

                var tempModules = Path.Combine(tempLocation, "Modules");
                if (FileActions.VerifyPath(tempModules, false))
                {
                    var folder = new DirectoryInfo(tempModules);
                    var content = folder.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
                    foreach (var file in content)
                    {
                        var dest = Path.Combine(moduleLocation, file.Name);

                        if (File.Exists(dest))
                            File.Delete(dest);

                        FileActions.VerifyFilePath(dest, true);
                        file.MoveTo(dest);
                    }
                }
            }

            LoadInstalled();
            Show();
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            var pluginLocation = Path.Combine(_server, "Rocket", "Plugins");
            var librariesLocation = Path.Combine(_server, "Rocket", "Libraries");

            FileActions.DeleteDirectory(pluginLocation);
            FileActions.DeleteDirectory(librariesLocation);

            LoadInstalled();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var pluginLocation = Path.Combine(_server, "Rocket", "Plugins", _itemId);

            FileActions.DeleteDirectory(pluginLocation);
            File.Delete($"{pluginLocation}.dll");

            LoadInstalled();
        }

        private void Configuration_Click(object sender, EventArgs e)
        {
            var pluginLocation = Path.Combine(_server, "Rocket", "Plugins", _itemId);

            if (FileActions.VerifyPath(pluginLocation, false))
                Process.Start(pluginLocation);
        }
    }
}
