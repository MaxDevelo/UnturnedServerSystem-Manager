using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Unturned_Server_System.Loading;
using Unturned_Server_System.Server_Instance;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Unturned_Server_System.Forms
{


    public partial class formAddServer : Form
    {
        public string NameServer;
        private readonly string _clone;
        private bool _accepted;
        Main frm;
        public formAddServer(string cloneServer = null)
        {
            InitializeComponent();
            _clone = cloneServer;
        }

        private void formAddServer_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _accepted = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void txtNameServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNameServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }
            _accepted = true;
            this.Close();
        }

        private void formAddServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            var illegalName =  new Regex( "(^(PRN|AUX|NUL|CON|COM[1-9]|LPT[1-9]|(\\.+)$)(\\..*)?$)|(([\\x00-\\x1f\\\\?*:\";‌​|/<>])+)|([\\.]+)",RegexOptions.IgnoreCase);

            if (!_accepted || illegalName.IsMatch(txtNameServer.Text) || string.IsNullOrEmpty(txtNameServer.Text))
            {
                return;
            }

            if (!Servers.RegisteredServers.Exists(k => k.Name == txtNameServer.Text))
            {
                Servers.RegisteredServers.Add(Server.Create(txtNameServer.Text, _clone));
            }
               
        }

        private void formAddServer_Load_1(object sender, EventArgs e)
        {

        }
    }
    
}
