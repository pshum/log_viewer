namespace LogViewer
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fbDia = new System.Windows.Forms.FolderBrowserDialog();
            this.lstFile = new System.Windows.Forms.ListBox();
            this.lstSec = new System.Windows.Forms.ListBox();
            this.lstWarn = new System.Windows.Forms.ListBox();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1021, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "&Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // lstFile
            // 
            this.lstFile.FormattingEnabled = true;
            this.lstFile.Location = new System.Drawing.Point(12, 27);
            this.lstFile.Name = "lstFile";
            this.lstFile.Size = new System.Drawing.Size(230, 251);
            this.lstFile.TabIndex = 1;
            this.lstFile.SelectedIndexChanged += new System.EventHandler(this.lstFile_SelectedIndexChanged);
            // 
            // lstSec
            // 
            this.lstSec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSec.FormattingEnabled = true;
            this.lstSec.Location = new System.Drawing.Point(12, 287);
            this.lstSec.Name = "lstSec";
            this.lstSec.Size = new System.Drawing.Size(229, 316);
            this.lstSec.TabIndex = 2;
            this.lstSec.SelectedIndexChanged += new System.EventHandler(this.lstSec_SelectedIndexChanged);
            // 
            // lstWarn
            // 
            this.lstWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWarn.FormattingEnabled = true;
            this.lstWarn.HorizontalScrollbar = true;
            this.lstWarn.Location = new System.Drawing.Point(249, 79);
            this.lstWarn.Name = "lstWarn";
            this.lstWarn.Size = new System.Drawing.Size(760, 524);
            this.lstWarn.TabIndex = 3;
            // 
            // grpBox
            // 
            this.grpBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox.Location = new System.Drawing.Point(249, 27);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(760, 43);
            this.grpBox.TabIndex = 4;
            this.grpBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 608);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.lstWarn);
            this.Controls.Add(this.lstSec);
            this.Controls.Add(this.lstFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbDia;
        private System.Windows.Forms.ListBox lstFile;
        private System.Windows.Forms.ListBox lstSec;
        private System.Windows.Forms.ListBox lstWarn;
        private System.Windows.Forms.GroupBox grpBox;
    }
}

