using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unturned_Server_System.Constants;
using Unturned_Server_System.Configuration;
using Unturned_Server_System.SteamCMD_Manager;
using static System.Windows.Forms.LinkLabel;

namespace Unturned_Server_System.Forms
{
    public partial class Workshop : Form
    {
        private readonly string _server;
        private bool _controlChange;
        private string _itemId = "";
        public Workshop(string serverPath)
        {
            InitializeComponent();
            String sURL = "https://steamcommunity.com/app/304930/workshop/?l=french";
            webBrowser1.Navigate(sURL);
            webBrowser1.ScriptErrorsSuppressed = true;
            _server = serverPath;
            LoadInstalled();
        }
        private void LoadInstalled()
        {
            AlreadyInstalled.Items.Clear();
            var workshopLocation = Path.Combine(_server, "Workshop", "Content");
            FileActions.VerifyPath(workshopLocation, true);

            var folder = new DirectoryInfo(workshopLocation);
            var content = folder.GetDirectories();
            foreach (var item in content)
                AlreadyInstalled.Items.Add(item.Name);

            workshopLocation = Path.Combine(_server, "Workshop", "Maps");
            FileActions.VerifyPath(workshopLocation, true);

            folder = new DirectoryInfo(workshopLocation);
            content = folder.GetDirectories();
            foreach (var item in content)
                AlreadyInstalled.Items.Add(item.Name);

            if (AlreadyInstalled.Items.Count == 0)
            {
                Delete.Enabled = false;
                
                UpdateAll.Enabled = false;
                DeleteAll.Enabled = false;
                _itemId = "";
            }
            else
            {
                AlreadyInstalled.SelectedIndex = 0;
                UpdateAll.Enabled = true;
                DeleteAll.Enabled = true;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mods installed with sucess !");
            string url = webBrowser1.Url.ToString();
            _controlChange = true;
            ID.Text = "";

            if (url.StartsWith("https://steamcommunity.com/sharedfiles/filedetails/?id=",
                StringComparison.Ordinal))
            {
                var id = url.Substring("https://steamcommunity.com/sharedfiles/filedetails/?id=".Length);

                var iid = "";
                foreach (var c in id)
                    if (ulong.TryParse("" + c, out var n))
                        iid += c;
                    else
                        break;

                if (ulong.TryParse(iid, out var uid))
                    ID.Text = iid;
            }
               else if (url.StartsWith("https://steamcommunity.com/workshop/filedetails/?id=",
                StringComparison.Ordinal))
            {
                var id = url.Substring("https://steamcommunity.com/workshop/filedetails/?id=".Length);

                var iid = "";
                foreach (var c in id)
                    if (ulong.TryParse("" + c, out var n))
                        iid += c;
                    else
                        break;

                if (ulong.TryParse(iid, out var uid))
                    ID.Text = iid;
            }

            _controlChange = false;
            Hide();
            if (!string.IsNullOrEmpty(ID.Text))
            {
                SteamCmd.RunCommand(
                    (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                        ? $"+force_install_dir \"{ServerPath.Value}\" "
                        : "") + $"+workshop_download_item 304930 {ID.Text} +quit");
                SteamCmd.MoveWorkshopFolder(ID.Text, Path.Combine(_server, "Workshop"));
            }

            LoadInstalled();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void AlreadyInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlreadyInstalled.SelectedItem != null)
            {
                Delete.Enabled = true;
                
                _itemId = (string)AlreadyInstalled.SelectedItem;
            }
            else
            {
                Delete.Enabled = false;
         
                _itemId = "";
            }
        }

        private void ID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Link_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            FileActions.DeleteDirectory(Path.Combine(_server, "Workshop"));
            LoadInstalled();
        }

        private void UpdateAll_Click(object sender, EventArgs e)
        {
            Hide();
            if (AlreadyInstalled.Items.Count > 0)
                foreach (string s in AlreadyInstalled.Items)
                {
                    SteamCmd.RunCommand(
                        (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                            ? $"+force_install_dir \"{ServerPath.Value}\" "
                            : "") + $"+workshop_download_item 304930 {ID.Text} +quit");
                    SteamCmd.MoveWorkshopFolder(s, Path.Combine(_server, "Workshop"));
                }

            LoadInstalled();
            Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_itemId))
            {
                FileActions.DeleteDirectory(Path.Combine(_server, "Workshop", "Content", _itemId));
                FileActions.DeleteDirectory(Path.Combine(_server, "Workshop", "Maps", _itemId));
            }

            LoadInstalled();
        }

        private void Workshop_Load(object sender, EventArgs e)
        {
           
        }
    }
}
