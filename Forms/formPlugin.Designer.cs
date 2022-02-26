
namespace Unturned_Server_System.Forms
{
    partial class formPlugin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPlugin));
            this.OpenZip = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDiscord = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.lblTitlePanel = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rJbutton1 = new Unturned_Server_System.RJbutton();
            this.rJbutton2 = new Unturned_Server_System.RJbutton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenZip
            // 
            this.OpenZip.FileName = "Open plugin zip";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(66)))), ((int)(((byte)(49)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(-1, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 593);
            this.panel2.TabIndex = 61;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(3, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(235, 53);
            this.button3.TabIndex = 48;
            this.button3.Text = "Permissions";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 53);
            this.button2.TabIndex = 47;
            this.button2.Text = "Plugins";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.89565F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "General";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.panelMenu);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnDiscord);
            this.panel1.Controls.Add(this.btnMini);
            this.panel1.Controls.Add(this.lblTitlePanel);
            this.panel1.Controls.Add(this.btnSetting);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.pnlLogo);
            this.panel1.Location = new System.Drawing.Point(-15, -12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 72);
            this.panel1.TabIndex = 20;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panelMenu
            // 
            this.panelMenu.Location = new System.Drawing.Point(21, 69);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(243, 593);
            this.panelMenu.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(207)))), ((int)(((byte)(44)))));
            this.label4.Location = new System.Drawing.Point(373, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 26);
            this.label4.TabIndex = 16;
            this.label4.Text = "Free and Easily";
            // 
            // btnDiscord
            // 
            this.btnDiscord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.btnDiscord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDiscord.BackgroundImage")));
            this.btnDiscord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscord.Location = new System.Drawing.Point(998, 13);
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(56, 51);
            this.btnDiscord.TabIndex = 15;
            this.btnDiscord.Tag = "5";
            this.btnDiscord.UseVisualStyleBackColor = false;
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.btnMini.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMini.BackgroundImage")));
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMini.Location = new System.Drawing.Point(1118, 16);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(47, 45);
            this.btnMini.TabIndex = 13;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // lblTitlePanel
            // 
            this.lblTitlePanel.AutoSize = true;
            this.lblTitlePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlePanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitlePanel.Location = new System.Drawing.Point(94, 30);
            this.lblTitlePanel.Name = "lblTitlePanel";
            this.lblTitlePanel.Size = new System.Drawing.Size(273, 26);
            this.lblTitlePanel.TabIndex = 11;
            this.lblTitlePanel.Text = "Unturned Server System";
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.btnSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetting.BackgroundImage")));
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Location = new System.Drawing.Point(1060, 14);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(52, 48);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Tag = "4";
            this.btnSetting.UseVisualStyleBackColor = false;
            // 
            // btnQuit
            // 
            this.btnQuit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuit.BackgroundImage")));
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuit.Location = new System.Drawing.Point(1171, 14);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(47, 45);
            this.btnQuit.TabIndex = 12;
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLogo.Location = new System.Drawing.Point(23, 14);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(54, 55);
            this.pnlLogo.TabIndex = 11;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.lblTitle);
            this.panelDesktopPane.Location = new System.Drawing.Point(244, 60);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(978, 526);
            this.panelDesktopPane.TabIndex = 62;
            this.panelDesktopPane.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktopPane_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.03478F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(414, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(106, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // rJbutton1
            // 
            this.rJbutton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(177)))), ((int)(((byte)(170)))));
            this.rJbutton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(177)))), ((int)(((byte)(170)))));
            this.rJbutton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rJbutton1.BorderRadius = 20;
            this.rJbutton1.BorderSize = 0;
            this.rJbutton1.FlatAppearance.BorderSize = 0;
            this.rJbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJbutton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJbutton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.rJbutton1.Location = new System.Drawing.Point(573, 613);
            this.rJbutton1.Name = "rJbutton1";
            this.rJbutton1.Size = new System.Drawing.Size(649, 24);
            this.rJbutton1.TabIndex = 1;
            this.rJbutton1.Text = "save";
            this.rJbutton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.rJbutton1.UseVisualStyleBackColor = false;
            // 
            // rJbutton2
            // 
            this.rJbutton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(177)))), ((int)(((byte)(170)))));
            this.rJbutton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(177)))), ((int)(((byte)(170)))));
            this.rJbutton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rJbutton2.BorderRadius = 20;
            this.rJbutton2.BorderSize = 0;
            this.rJbutton2.FlatAppearance.BorderSize = 0;
            this.rJbutton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJbutton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJbutton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rJbutton2.Location = new System.Drawing.Point(244, 614);
            this.rJbutton2.Name = "rJbutton2";
            this.rJbutton2.Size = new System.Drawing.Size(323, 24);
            this.rJbutton2.TabIndex = 63;
            this.rJbutton2.Text = "return";
            this.rJbutton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rJbutton2.UseVisualStyleBackColor = false;
            this.rJbutton2.Click += new System.EventHandler(this.rJbutton2_Click);
            // 
            // formPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1220, 650);
            this.Controls.Add(this.rJbutton2);
            this.Controls.Add(this.rJbutton1);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1220, 650);
            this.MinimumSize = new System.Drawing.Size(1220, 650);
            this.Name = "formPlugin";
            this.Text = "Plugin";
            this.Load += new System.EventHandler(this.Plugin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Plugin_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.panelDesktopPane.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenZip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDiscord;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.Label lblTitlePanel;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMenu;
        private RJbutton rJbutton1;
        private RJbutton rJbutton2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}