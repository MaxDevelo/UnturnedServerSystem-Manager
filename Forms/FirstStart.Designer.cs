
namespace Unturned_Server_System
{
    partial class FirstStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstStart));
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelectedPath = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.Location = new System.Drawing.Point(624, 193);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(117, 25);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Install package";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectedPath);
            this.groupBox1.Controls.Add(this.button);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(159, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 55);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // SelectedPath
            // 
            this.SelectedPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.SelectedPath.Location = new System.Drawing.Point(197, 18);
            this.SelectedPath.Name = "SelectedPath";
            this.SelectedPath.Size = new System.Drawing.Size(263, 22);
            this.SelectedPath.TabIndex = 4;
            this.SelectedPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // button
            // 
            this.button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button.Location = new System.Drawing.Point(478, 17);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(117, 25);
            this.button.TabIndex = 3;
            this.button.Text = "Browse...";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(25, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination Folder:";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle1.Location = new System.Drawing.Point(193, 33);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(226, 24);
            this.lblTitle1.TabIndex = 14;
            this.lblTitle1.Text = "Choose Install Location";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(-12, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 129);
            this.panel1.TabIndex = 13;
            // 
            // FirstStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(772, 230);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FirstStart";
            this.Text = "Unturned Server System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FirstStart_FormClosing);
            this.Load += new System.EventHandler(this.FirstStart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SelectedPath;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
    }
}