using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Unturned_Server_System.Confiduration;
using Unturned_Server_System.Constants;

namespace Unturned_Server_System.Forms
{
    public partial class Main : Form
    {
        private bool _otherGuiOpen;
        private bool _reloaded;
        private string _selectedServer = "";
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public Main()
        {
            InitializeComponent();
            BuildNotifyMenu();
            this.Servers.DrawMode = DrawMode.OwnerDrawFixed;
            this.Servers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(Servers_DrawItem);
            this.Servers.SelectedIndexChanged += new System.EventHandler(Servers_SelectedIndexChanged);

            LoadServers();
        }
        private void BuildNotifyMenu()
        {
            var menu = new ContextMenu();
            var exit = new MenuItem();
            var wiki = new MenuItem();
            var issues = new MenuItem();
            menu.MenuItems.AddRange(new[] { exit, wiki, issues });
            exit.Index = 0;
            exit.Text = @"Exit";

            wiki.Index = 0;
            wiki.Text = @"Wiki";
            issues.Index = 0;
            issues.Text = @"Issues And Suggestions";
        }

        private void LoadServers()
        {
            _reloaded = true;

            Servers.Items.Clear();

            foreach (var s in Loading.Servers.RegisteredServers)
                Servers.Items.Add(s.Name);

            if (Servers.Items.Count == 0)
            {
                ToggleServerElements(false);
                richTextBox1.Text = "";
            }
            else
            {
                ToggleServerElements(true);
                Servers.SelectedIndex = 0;

                _selectedServer = (string)Servers.SelectedItem;

                LoadServerDetails();
            }

            _reloaded = false;
        }

        private void ToggleServerElements(bool status)
        {
            Settings.Enabled = status;
            richTextBox1.Enabled = status;
            Toggle.Enabled = status;
            OpenLocal.Enabled = status;
            Restart.Enabled = false;
            Workshop.Enabled = status;
            Plugin.Enabled = status;
            DeleteServer.Enabled = status;
        }

        private void LoadServerDetails()
        {
            richTextBox1.Text = GameConfiguration.Load(_selectedServer).ToString();

            var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer);
            if (server == null) return;

            Restart.Enabled = server.IsRunning;
        }
        WaitForm waitForm = new WaitForm();
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            starting.Visible = false;
            shutdown.Visible = false;
            Restart.Visible = false;
        }

        private void Toggle_Click(object sender, EventArgs e)
        {

            DeleteServer.Enabled = false;
            Plugin.Enabled = false;
            Workshop.Enabled = false;
            OpenLocal.Enabled = false;
            var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer);
            if (server == null) return;
            try
            {
                starting.Visible = true;

                int sleepTime = 2000; // in mills
                Task.Delay(sleepTime).Wait();
                // or
                Thread.Sleep(sleepTime);
                server.Start();
                starting.Visible = false;
                shutdown.Visible = true;
                Restart.Enabled = true;
                Restart.Visible = true;

            }
            catch { }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (_reloaded) return;

            _selectedServer = (string)Servers.SelectedItem;

            LoadServerDetails();
        }

        private void shutdown_Click(object sender, EventArgs e)
        {
            var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer);
            Restart.Enabled = false;
            server.Shutdown();
            shutdown.Visible = false;
            Restart.Visible = false;
            DeleteServer.Enabled = true;
            Plugin.Enabled = true;
            Workshop.Enabled = true;
            OpenLocal.Enabled = true;
        }

        private void NewServer_Click(object sender, EventArgs e)
        {
            _otherGuiOpen = true;
            Hide();

            var f = new formAddServer();
            f.ShowDialog();

            Show();
            _otherGuiOpen = false;
            LoadServers();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void OpenLocal_Click(object sender, EventArgs e)
        {
            var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer);
            if (server != null)
                Process.Start(server.Folder);
   
        }

        private void DeleteServer_Click(object sender, EventArgs e)
        {
            var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer);
            if (server?.IsRunning == true)
                server.Shutdown();

            server?.Delete();

            LoadServers();
            Servers.SelectedItem = false;
        }

        private void Servers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Servers.Invalidate();
            if (_reloaded) return;

            _selectedServer = (string)Servers.SelectedItem;

            LoadServerDetails();
            lblTitle.Text = "Server: " + _selectedServer;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            _otherGuiOpen = true;
            Hide();

            var f = new formSetupServer(_selectedServer);
            f.ShowDialog();

            Show();
            _otherGuiOpen = false;
            LoadServers();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _otherGuiOpen = true;
            Hide();

            var f = new update();
            f.ShowDialog();

            Show();
            _otherGuiOpen = false;
            LoadServers();
        }

        private void starting_Click(object sender, EventArgs e)
        {

        }

        private void Toggle_MouseDown(object sender, MouseEventArgs e)
        {

        }
        int hWnd = 0;

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        public object RocketModConfig { get;  set; }

        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            int hWnd;
            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.ProcessName == "Unturned")
                {
                    hWnd = pr.MainWindowHandle.ToInt32();
                    if (hWnd != 0)
                    {
                        ShowWindow(hWnd, SW_SHOW);
                        hWnd = 0;
                    }
                    else
                    {
                 
                    ShowWindow(hWnd, SW_HIDE);
                    }
                    
                }
               
            }
          
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer);
            server?.Restart();
        }

      
        /* var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer);
            RocketConfig v = new RocketConfig(Loading.Servers.RegisteredServers.Find(k => k.Name == _selectedServer));
            DirectoryInfo ng = new DirectoryInfo(server.Folder + "\\Rocket\\");
       
            RocketPermissionConfig n = new RocketPermissionConfig(ng);
            n.createGroup("teste");
           
            n.removeGroup("default");*/
        private void Plugin_Click(object sender, EventArgs e)
        {
            _otherGuiOpen = true;
            Hide();

            var f = new formPlugin(_selectedServer);
            f.ShowDialog();

            Show();
            _otherGuiOpen = false;
            LoadServers();
        }

        private void Servers_DrawItem(object sender, DrawItemEventArgs e)
        {
            int index = e.Index;
            Graphics g = e.Graphics;
            foreach (int selectedIndex in this.Servers.SelectedIndices)
            {
                if (index == selectedIndex)
                {
                    // Draw the new background colour
                    e.DrawBackground();
                    g.FillRectangle(new SolidBrush(Color.FromArgb(61, 92, 61)), e.Bounds);
                }
            }

            // Get the item details
            Font font = Servers.Font;
            Color colour = Servers.ForeColor;
            string text = Servers.Items[index].ToString();

            // Print the text
            g.DrawString(text, font, new SolidBrush(Color.White), (float)e.Bounds.X, (float)e.Bounds.Y);
            e.DrawFocusRectangle();
        }

        private void btnDiscord_Click(object sender, EventArgs e)
        {
            Process.Start(https://discord.gg/4UdrP2pNy4);
        }
    }
}
