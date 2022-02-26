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
using System.Threading.Tasks;
using System.Windows.Forms;
using Unturned_Server_System.Constants;
using Unturned_Server_System.Configuration;

namespace Unturned_Server_System.Forms
{

    internal sealed partial class formPlugin : Form
#pragma warning disable CS0169 // Le champ 'Plugin._otherGuiOpen' n'est jamais utilisé
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private bool _otherGuiOpen;
#pragma warning restore CS0169 // Le champ 'Plugin._otherGuiOpen' n'est jamais utilisé
        private readonly string _server;
        private string _itemId = "";
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public formPlugin(string serverPath)
        {
            InitializeComponent();
            _server = serverPath;
            LoadInstalled();
 
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void LoadInstalled()
        {
       
            var pluginLocation = Path.Combine(_server, "Rocket", "Plugins");
            FileActions.VerifyPath(pluginLocation, true);

            var folder = new DirectoryInfo(pluginLocation);
            var content = folder.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
          
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Settings Rocket Mod";
            currentButton = null;
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

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlreadyInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private void Configuration_Click(object sender, EventArgs e)
        {
            var pluginLocation = Path.Combine(_server, "Rocket", "Plugins", _itemId);

            if (FileActions.VerifyPath(pluginLocation, false))
                Process.Start(pluginLocation);
        }

        private void Plugin_Load(object sender, EventArgs e)
        {

        }

        private void Plugin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rJbutton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PluginPage.Plugins(_server), sender);
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
