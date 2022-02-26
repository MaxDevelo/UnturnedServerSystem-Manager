
namespace Unturned_Server_System.Forms.PluginPage
{
    partial class Plugins
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plugins));
            this.AlreadyInstalled = new System.Windows.Forms.ListBox();
            this.Install = new System.Windows.Forms.Button();
            this.DeleteAll = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Configuration = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.OpenZip = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // AlreadyInstalled
            // 
            this.AlreadyInstalled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.AlreadyInstalled.Font = new System.Drawing.Font("Microsoft YaHei", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlreadyInstalled.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.AlreadyInstalled.FormattingEnabled = true;
            this.AlreadyInstalled.ItemHeight = 22;
            this.AlreadyInstalled.Location = new System.Drawing.Point(7, 61);
            this.AlreadyInstalled.Margin = new System.Windows.Forms.Padding(4);
            this.AlreadyInstalled.Name = "AlreadyInstalled";
            this.AlreadyInstalled.Size = new System.Drawing.Size(964, 356);
            this.AlreadyInstalled.TabIndex = 42;
            this.AlreadyInstalled.SelectedIndexChanged += new System.EventHandler(this.AlreadyInstalled_SelectedIndexChanged);
            // 
            // Install
            // 
            this.Install.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(122)))), ((int)(((byte)(84)))));
            this.Install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Install.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Install.ForeColor = System.Drawing.Color.White;
            this.Install.Image = ((System.Drawing.Image)(resources.GetObject("Install.Image")));
            this.Install.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Install.Location = new System.Drawing.Point(690, 424);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(276, 51);
            this.Install.TabIndex = 45;
            this.Install.Text = "Install From Zip";
            this.Install.UseVisualStyleBackColor = false;
            this.Install.Click += new System.EventHandler(this.Install_Click);
            // 
            // DeleteAll
            // 
            this.DeleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAll.ForeColor = System.Drawing.Color.White;
            this.DeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("DeleteAll.Image")));
            this.DeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteAll.Location = new System.Drawing.Point(348, 431);
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(267, 44);
            this.DeleteAll.TabIndex = 47;
            this.DeleteAll.Text = "Delete All";
            this.DeleteAll.UseVisualStyleBackColor = false;
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete.Location = new System.Drawing.Point(690, 481);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(276, 37);
            this.Delete.TabIndex = 48;
            this.Delete.Text = "Delete Plugin";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Configuration
            // 
            this.Configuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(156)))), ((int)(((byte)(158)))));
            this.Configuration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Configuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Configuration.ForeColor = System.Drawing.Color.White;
            this.Configuration.Image = ((System.Drawing.Image)(resources.GetObject("Configuration.Image")));
            this.Configuration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Configuration.Location = new System.Drawing.Point(7, 476);
            this.Configuration.Name = "Configuration";
            this.Configuration.Size = new System.Drawing.Size(210, 38);
            this.Configuration.TabIndex = 49;
            this.Configuration.Text = "Open Config";
            this.Configuration.UseVisualStyleBackColor = false;
            this.Configuration.Click += new System.EventHandler(this.Configuration_Click);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblServer.Location = new System.Drawing.Point(343, 23);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(317, 30);
            this.lblServer.TabIndex = 50;
            this.lblServer.Text = "Plugins Already Installed";
            // 
            // OpenZip
            // 
            this.OpenZip.FileName = "Open plugin zip";
            // 
            // Plugins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(978, 526);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.Configuration);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.DeleteAll);
            this.Controls.Add(this.Install);
            this.Controls.Add(this.AlreadyInstalled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(978, 526);
            this.MinimumSize = new System.Drawing.Size(978, 526);
            this.Name = "Plugins";
            this.Text = "Plugins";
            this.Load += new System.EventHandler(this.Plugins_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AlreadyInstalled;
        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.Button DeleteAll;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Configuration;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.OpenFileDialog OpenZip;
    }
}