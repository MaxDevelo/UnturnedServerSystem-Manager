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
using Unturned_Server_System.Confiduration;
using Unturned_Server_System.Constants;
using Unturned_Server_System.Configuration;
using Unturned_Server_System.Loading;
namespace Unturned_Server_System.Forms
{
    public partial class formSetupServer : Form
    {

        private readonly string _targetServer;
        public string _selectedServer;
        public formSetupServer(string serverName)
        {
          
            InitializeComponent();

            _targetServer = serverName;

            LoadMaps();
            LoadSaved();
            btnLoadout.Enabled = false;
        }
        // Custom Methods
        private void LoadMaps()
        {
            var server = Servers.RegisteredServers.Find(k => k.Name == _targetServer);
            var dir = Path.Combine(ServerPath.Value, "Maps");
            FileActions.VerifyPath(dir, true);

            var rocketModDirectoryInfo = new DirectoryInfo(dir);
            foreach (var rocketServer in rocketModDirectoryInfo.GetDirectories())
                cboMaps.Items.Add(rocketServer.Name);

            var workshopMaps = Path.Combine(server.Folder, "Workshop", "Maps");
            FileActions.VerifyPath(workshopMaps, true);

            var folder = new DirectoryInfo(workshopMaps);
            var content = folder.GetDirectories();
            foreach (var mapName in content.SelectMany(item => item.GetDirectories()))
                cboMaps.Items.Add(mapName.Name);
        }

        private void Save()
        {
            var conf = GameConfiguration.Load(_targetServer);
            conf.PublicName = txtPubName.Text.Length < 5 ? "Unturned" : txtPubName.Text;
            conf.Port = (int)txtPort.Value;
            conf.Pvp = rdbPvp.Checked;
            conf.Perspective = rdbFirst.Checked ? "First" : "Both";
            conf.MaxPlayers = (int)MaxPlayer.Value;
            conf.Map = (string)cboMaps.SelectedItem;
            conf.Difficulty = rdbEasy.Checked ? "Easy" : rdbNormal.Checked ? "Normal" : "Hard";
            conf.GoldMode = rjGold.Checked;
            conf.Cheats = rjCheat.Checked;
            conf.Password = txtPassword.Text;
  
            conf.Owner = (long)OwnerId.Value;
            conf.LoginMessage = txtWelcome.Text;
    
            conf.HideAdmins = rjHideAdmin.Checked;
            conf.Cycle = (int)cycle.Value;
            conf.SaveJson();

            var commandsDat = Path.Combine(ServerPath.Value, "Servers", _targetServer, "Server", "Commands.dat");
            FileActions.VerifyFilePath(commandsDat, true);
            File.WriteAllLines(commandsDat, conf.ToNelson);

            Close();
        }

        private void LoadSaved()
        {
            var conf = GameConfiguration.Load(_targetServer);

            var bindBytes = conf.Bind.Split('.').ToList().ConvertAll(k =>
            {
                if (byte.TryParse(k, out var r))
                    return r;

                return (byte)0;
            });


            txtPubName.Text = conf.PublicName;
            txtPort.Value = conf.Port;

            cboMaps.SelectedIndex = string.IsNullOrEmpty(conf.Map) ? 0 : cboMaps.Items.IndexOf(conf.Map);

            txtPubName.Text = conf.Password;
            OwnerId.Value = conf.Owner;
            txtWelcome.Text = conf.LoginMessage;


            if (conf.Pvp)
                rdbPvp.Checked = true;
            else
                rdbPve.Checked = true;

            if (conf.GoldMode)
                rjGold.Checked = true;
            else
                rjGold.Checked = false;

            if (conf.Cheats)
                rjCheat.Checked = true;
            else
                rjCheat.Checked = false;

            if (conf.HideAdmins)
                rjHideAdmin.Checked = true;
            else
                rjHideAdmin.Checked = false;

  

            switch (conf.Perspective)
            {
                case "First":
                    rdbFirst.Checked = true;
                    break;
                case "Both":
                    rdbBoth.Checked = true;
                    break;
                default:
                    rdbThird.Checked = true;
                    break;
            }

            switch (conf.Difficulty)
            {
                case "Easy":
                    rdbEasy.Checked = true;
                    break;
                case "Normal":
                    rdbNormal.Checked = true;
                    break;
                case "Hard":
                    rdbHard.Checked = true;
                    break;
                default:
                    rdbNormal.Checked = true;
                    break;
            }

            
                cycle.Value = conf.Cycle;
        

       
        }

        // Control Update Methods
     /*   private void QueueChange()
        {
            if (QueueSize1.Checked || QueueSize2.Checked || QueueSize3.Checked)
                Queue.Enabled = false;
            else if (QueueSize4.Checked)
                Queue.Enabled = true;
        }

        private void CycleChange()
        {
            if (Cycle1.Checked)
                Cycle.Enabled = false;
            else if (Cycle2.Checked)
                Cycle.Enabled = true;
        }

        private void MaxPlayersChange()
        {
            if (MaxPlayersVal1.Checked || MaxPlayersVal2.Checked || MaxPlayersVal3.Checked)
                MaxPlayers.Enabled = false;
            else if (MaxPlayersVal4.Checked)
                MaxPlayers.Enabled = true;
        }

        private void ChatChange()
        {
            if (Rate1.Checked)
                ChatRate.Enabled = false;
            else if (Rate2.Checked)
                ChatRate.Enabled = true;
        }*/

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
          
            
        }

       private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            /* port = int.Parse(txtPort.Text);
             publicName = txtPubName.Text;


             string cCheat;
             if(rjCheat.Checked)
             {
                 cCheat = "enabled";
             }
             else
             {
                 cCheat = "disabled";
             }
             maxPlayers = int.Parse(txtMaxPlayer.Text);
             messageWelcome = txtWelcome.Text;
             mode = modeJeu();
             perspective = modePerspective();
             damage = modeDammage();
             string fileCommand = @"C:\Users\" + Environment.UserName + @"\Desktop\bureau\commands.dat";

             if (File.Exists(fileCommand)) { File.Delete(fileCommand); }
             using (StreamWriter writetext = File.CreateText(fileCommand))
             {
                 //Map
                 writetext.WriteLine("map " + maps[cboMaps.SelectedIndex]);
                 writetext.WriteLine("port " + port);
                 writetext.WriteLine("name " + publicName);
                 writetext.WriteLine("perspective " + perspective);
                 writetext.WriteLine("cheats " + cCheat);
                 writetext.WriteLine("maxplayers " + maxPlayers);
                 writetext.WriteLine("welcome " + messageWelcome);
                 writetext.WriteLine("mode " + mode);
                 writetext.WriteLine(damage);
                 if(rjHideAdmin.Checked)
                 {
                     writetext.WriteLine("hide_admin");
                 }
                 writetext.WriteLine("timeout 1000");
                 owner = int.Parse(txtOwner.Text);
                 writetext.WriteLine("Admins " + owner);
                 writetext.WriteLine("chatrate");
                 if (rjGold.Checked)
                 {
                     writetext.WriteLine("gold");
                 }
                 writetext.Close();
             }
             this.Close();
         }



         public void AddToTextBox(string selectedItem)
         {
             instanceName = selectedItem;
         }
         private void formSetupServer_Load(object sender, EventArgs e)
         {
             txtInstName.Text = instanceName;
             cboMaps.Items.AddRange(maps);
         }
       public string modeJeu()
         {
             if(rdbEasy.Checked)
             {
                 return rdbEasy.Text;
             }
             else if(rdbNormal.Checked)
             {
                 return rdbNormal.Text;
             }
             else
             {
                 return rdbHard.Text;
             }
         }

         public string modePerspective()
         {
             if (rdbBoth.Checked)
             {
                 return rdbBoth.Text;
             }
             else if (rdbFirst.Checked)
             {
                 return rdbFirst.Text;
             }
             else
             {
                 return rdbThird.Text;
             }
         }

         public string modeDammage()
         {
             if (rdbPve.Checked)
             {
                 return rdbPve.Text;
             }
             else
             {
                 return rdbPvp.Text;
             }*/
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoadout_Click(object sender, EventArgs e)
        {

        }

        private void MaxPlayer_ValueChanged(object sender, EventArgs e)
        {

        }
        private void formSetupServer_Load(object sender, EventArgs e)
        {
    
        }

        private void btnEditC_Click(object sender, EventArgs e)
        {
            
            var server = Loading.Servers.RegisteredServers.Find(k => k.Name == _targetServer);
            if (server != null)
            {
             
    

                Process.Start("notepad.exe", server.Folder + @"\Config.json");
            }
        }
    }

}
