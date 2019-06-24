namespace ReExtractor
{
    partial class MainForm
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
            this.FolderTree = new ReExtractor.FolderTreeView();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.OpenStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FileStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.IamSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.ExtractStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.VerifyStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DecryptStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.CurrentPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectedItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileList = new ReExtractor.FilesListView();
            this.SaveDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FolderTree
            // 
            this.FolderTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.FolderTree.HideSelection = false;
            this.FolderTree.LineColor = System.Drawing.Color.Blue;
            this.FolderTree.Location = new System.Drawing.Point(20, 85);
            this.FolderTree.Name = "FolderTree";
            this.FolderTree.Size = new System.Drawing.Size(208, 323);
            this.FolderTree.Sorted = true;
            this.FolderTree.TabIndex = 0;
            this.FolderTree.ShowFolder += new System.EventHandler<ReExtractor.FilesEventArgs>(this.FolderTree_ShowFolder);
            this.FolderTree.ExtractFolder += new System.EventHandler<ReExtractor.FilesEventArgs>(this.ExtractFiles);
            this.FolderTree.VerifyFolder += new System.EventHandler<ReExtractor.FilesEventArgs>(this.VerifyFiles);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenStrip,
            this.FileStrip,
            this.AboutStrip,
            this.ExitStrip});
            this.MenuStrip.Location = new System.Drawing.Point(20, 60);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(610, 25);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // OpenStrip
            // 
            this.OpenStrip.Name = "OpenStrip";
            this.OpenStrip.Size = new System.Drawing.Size(52, 21);
            this.OpenStrip.Text = "Open";
            this.OpenStrip.Click += new System.EventHandler(this.OpenStrip_Click);
            // 
            // FileStrip
            // 
            this.FileStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAllStrip,
            this.IamSeperator,
            this.ExtractStrip,
            this.VerifyStrip,
            this.DecryptStrip});
            this.FileStrip.Name = "FileStrip";
            this.FileStrip.Size = new System.Drawing.Size(39, 21);
            this.FileStrip.Text = "File";
            // 
            // SelectAllStrip
            // 
            this.SelectAllStrip.Name = "SelectAllStrip";
            this.SelectAllStrip.Size = new System.Drawing.Size(180, 22);
            this.SelectAllStrip.Text = "Select All";
            this.SelectAllStrip.Click += new System.EventHandler(this.SelectAllStrip_Click);
            // 
            // IamSeperator
            // 
            this.IamSeperator.Name = "IamSeperator";
            this.IamSeperator.Size = new System.Drawing.Size(177, 6);
            // 
            // ExtractStrip
            // 
            this.ExtractStrip.Name = "ExtractStrip";
            this.ExtractStrip.Size = new System.Drawing.Size(180, 22);
            this.ExtractStrip.Text = "Extract All";
            this.ExtractStrip.Click += new System.EventHandler(this.ExtractStrip_Click);
            // 
            // VerifyStrip
            // 
            this.VerifyStrip.Name = "VerifyStrip";
            this.VerifyStrip.Size = new System.Drawing.Size(180, 22);
            this.VerifyStrip.Text = "Verify All";
            this.VerifyStrip.Click += new System.EventHandler(this.VerifyStrip_Click);
            // 
            // DecryptStrip
            // 
            this.DecryptStrip.CheckOnClick = true;
            this.DecryptStrip.Name = "DecryptStrip";
            this.DecryptStrip.Size = new System.Drawing.Size(180, 22);
            this.DecryptStrip.Text = "Decrypt Models";
            this.DecryptStrip.Click += new System.EventHandler(this.DecryptStrip_Click);
            // 
            // AboutStrip
            // 
            this.AboutStrip.Name = "AboutStrip";
            this.AboutStrip.Size = new System.Drawing.Size(55, 21);
            this.AboutStrip.Text = "About";
            // 
            // ExitStrip
            // 
            this.ExitStrip.Name = "ExitStrip";
            this.ExitStrip.Size = new System.Drawing.Size(40, 21);
            this.ExitStrip.Text = "Exit";
            this.ExitStrip.Click += new System.EventHandler(this.ExitStrip_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentPath,
            this.SelectedItem});
            this.StatusStrip.Location = new System.Drawing.Point(20, 408);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(610, 22);
            this.StatusStrip.TabIndex = 5;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // CurrentPath
            // 
            this.CurrentPath.Name = "CurrentPath";
            this.CurrentPath.Size = new System.Drawing.Size(464, 17);
            this.CurrentPath.Spring = true;
            this.CurrentPath.Text = "toolStripStatusLabel1";
            this.CurrentPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SelectedItem
            // 
            this.SelectedItem.Name = "SelectedItem";
            this.SelectedItem.Size = new System.Drawing.Size(131, 17);
            this.SelectedItem.Text = "toolStripStatusLabel2";
            this.SelectedItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FileList
            // 
            this.FileList.BackColor = System.Drawing.SystemColors.Window;
            this.FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FileList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FileList.FullPath = null;
            this.FileList.FullRowSelect = true;
            this.FileList.HideSelection = false;
            this.FileList.Location = new System.Drawing.Point(228, 85);
            this.FileList.Name = "FileList";
            this.FileList.OwnerDraw = true;
            this.FileList.Size = new System.Drawing.Size(402, 323);
            this.FileList.SortColumnOrder = System.Windows.Forms.SortOrder.None;
            this.FileList.TabIndex = 1;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.UseSelectable = true;
            this.FileList.View = System.Windows.Forms.View.Details;
            this.FileList.ExtractFile += new System.EventHandler<ReExtractor.FilesEventArgs>(this.ExtractFiles);
            this.FileList.VerifyFile += new System.EventHandler<ReExtractor.FilesEventArgs>(this.VerifyFiles);
            this.FileList.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            // 
            // SaveDialog
            // 
            this.SaveDialog.Description = "Select folder to extract files to. Note that the archive\'s folder structure will " +
    "be replicated in whichever folder you select.";
            // 
            // OpenDialog
            // 
            this.OpenDialog.DefaultExt = "nar";
            this.OpenDialog.FileName = "openFileDialog1";
            this.OpenDialog.Filter = "NAR Files|*.nar|All files|*.*";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.FolderTree);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.StatusStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "NAR Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderTreeView FolderTree;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenStrip;
        private System.Windows.Forms.ToolStripMenuItem FileStrip;
        private System.Windows.Forms.ToolStripMenuItem SelectAllStrip;
        private System.Windows.Forms.ToolStripSeparator IamSeperator;
        private System.Windows.Forms.ToolStripMenuItem ExtractStrip;
        private System.Windows.Forms.ToolStripMenuItem VerifyStrip;
        private System.Windows.Forms.ToolStripMenuItem DecryptStrip;
        private System.Windows.Forms.ToolStripMenuItem AboutStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitStrip;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private FilesListView FileList;
        private System.Windows.Forms.ToolStripStatusLabel CurrentPath;
        private System.Windows.Forms.ToolStripStatusLabel SelectedItem;
        private System.Windows.Forms.FolderBrowserDialog SaveDialog;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
    }
}

