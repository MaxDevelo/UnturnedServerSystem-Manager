
namespace Unturned_Server_System.Forms
{
    partial class Workshop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workshop));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AlreadyInstalled = new System.Windows.Forms.ListBox();
            this.DeleteAll = new System.Windows.Forms.Button();
            this.UpdateAll = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(321, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(779, 551);
            this.webBrowser1.TabIndex = 8;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(861, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "download mods";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 614);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 49);
            this.button2.TabIndex = 10;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlreadyInstalled
            // 
            this.AlreadyInstalled.BackColor = System.Drawing.SystemColors.Menu;
            this.AlreadyInstalled.FormattingEnabled = true;
            this.AlreadyInstalled.ItemHeight = 16;
            this.AlreadyInstalled.Location = new System.Drawing.Point(2, 9);
            this.AlreadyInstalled.Margin = new System.Windows.Forms.Padding(4);
            this.AlreadyInstalled.Name = "AlreadyInstalled";
            this.AlreadyInstalled.Size = new System.Drawing.Size(312, 548);
            this.AlreadyInstalled.TabIndex = 38;
            this.AlreadyInstalled.SelectedIndexChanged += new System.EventHandler(this.AlreadyInstalled_SelectedIndexChanged);
            // 
            // DeleteAll
            // 
            this.DeleteAll.Enabled = false;
            this.DeleteAll.Location = new System.Drawing.Point(2, 569);
            this.DeleteAll.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(83, 28);
            this.DeleteAll.TabIndex = 44;
            this.DeleteAll.Text = "Delete All";
            this.DeleteAll.UseVisualStyleBackColor = true;
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAll_Click);
            // 
            // UpdateAll
            // 
            this.UpdateAll.Enabled = false;
            this.UpdateAll.Location = new System.Drawing.Point(93, 569);
            this.UpdateAll.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateAll.Name = "UpdateAll";
            this.UpdateAll.Size = new System.Drawing.Size(87, 28);
            this.UpdateAll.TabIndex = 45;
            this.UpdateAll.Text = "Update All";
            this.UpdateAll.UseVisualStyleBackColor = true;
            this.UpdateAll.Click += new System.EventHandler(this.UpdateAll_Click);
            // 
            // Delete
            // 
            this.Delete.Enabled = false;
            this.Delete.Location = new System.Drawing.Point(188, 569);
            this.Delete.Margin = new System.Windows.Forms.Padding(4);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(123, 28);
            this.Delete.TabIndex = 46;
            this.Delete.Text = "Delete Selected";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(621, 400);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(100, 22);
            this.ID.TabIndex = 47;
            // 
            // Workshop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1140, 675);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.UpdateAll);
            this.Controls.Add(this.DeleteAll);
            this.Controls.Add(this.AlreadyInstalled);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.ID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Workshop";
            this.Text = "Unturned Server System Workshop";
            this.Load += new System.EventHandler(this.Workshop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox AlreadyInstalled;
        private System.Windows.Forms.Button DeleteAll;
        private System.Windows.Forms.Button UpdateAll;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox ID;
    }
}