using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unturned_Server_System.Confiduration;
using Unturned_Server_System.Updating;

namespace Unturned_Server_System.Forms
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
            LoadVersions();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void update_Load(object sender, EventArgs e)
        {
         

            btnReload.FlatAppearance.BorderSize = 0;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnDiscord.FlatAppearance.BorderSize = 0;
            btnQuit.FlatAppearance.BorderSize = 0;
            btnMini.FlatAppearance.BorderSize = 0;
        }
        private void LoadVersions()
        {
            var installedVersions = LocalVersions.Load();
          
        }
        private void UValidate_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.ValidateUnturned();
            LoadVersions();

            Show();
        }

        private void UAll_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateAll();
            LoadVersions();

            Show();
        }

        private void URocket_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateRocket();
            LoadVersions();

            Show();
        }

        private void UUnturned_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateUnturned();
            LoadVersions();

            Show();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
            Hide();

            Updater.UpdateRocket();
            LoadVersions();

            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateAll();
            LoadVersions();

            Show();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateUnturned();
            LoadVersions();

            Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDiscord_Click(object sender, EventArgs e)
        {
            Process.Start(https://discord.gg/4UdrP2pNy4);
        }

        private void rJbutton1_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateUnturned();
            LoadVersions();

            Show();
        }

        private void rJbutton2_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateAll();
            LoadVersions();

            Show();
        }

        private void rJbutton3_Click(object sender, EventArgs e)
        {
            Hide();

            Updater.UpdateRocket();
            LoadVersions();

            Show();
        }
    }
    
}
