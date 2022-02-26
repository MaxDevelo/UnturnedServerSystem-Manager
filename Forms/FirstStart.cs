using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unturned_Server_System.Confiduration;

namespace Unturned_Server_System
{
    public partial class FirstStart : Form
    {
        public FirstStart()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void FirstStart_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0103 // Le nom 'FolderBrowser' n'existe pas dans le contexte actuel
            var result = FolderBrowser.ShowDialog();
#pragma warning restore CS0103 // Le nom 'FolderBrowser' n'existe pas dans le contexte actuel
            if (result == DialogResult.OK)
#pragma warning disable CS0103 // Le nom 'FolderBrowser' n'existe pas dans le contexte actuel
                SelectedPath.Text = FolderBrowser.SelectedPath;
#pragma warning restore CS0103 // Le nom 'FolderBrowser' n'existe pas dans le contexte actuel
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void FirstStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            var inst = Installation.Load();
            inst.InstallationPath = SelectedPath.Text;
            inst.SaveJson();
        }
    }
}
