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
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.extractAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.CurrentPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectedItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileList = new ReExtractor.FilesListView();
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
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(20, 60);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(760, 25);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.extractAllToolStripMenuItem,
            this.verifyAllToolStripMenuItem,
            this.decryptModelsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // extractAllToolStripMenuItem
            // 
            this.extractAllToolStripMenuItem.Name = "extractAllToolStripMenuItem";
            this.extractAllToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.extractAllToolStripMenuItem.Text = "Extract All";
            // 
            // verifyAllToolStripMenuItem
            // 
            this.verifyAllToolStripMenuItem.Name = "verifyAllToolStripMenuItem";
            this.verifyAllToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.verifyAllToolStripMenuItem.Text = "Verify All";
            // 
            // decryptModelsToolStripMenuItem
            // 
            this.decryptModelsToolStripMenuItem.Name = "decryptModelsToolStripMenuItem";
            this.decryptModelsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.decryptModelsToolStripMenuItem.Text = "Decrypt Models";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentPath,
            this.SelectedItem});
            this.StatusStrip.Location = new System.Drawing.Point(20, 408);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(760, 22);
            this.StatusStrip.TabIndex = 5;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // CurrentPath
            // 
            this.CurrentPath.Name = "CurrentPath";
            this.CurrentPath.Size = new System.Drawing.Size(614, 17);
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
            this.FileList.Size = new System.Drawing.Size(552, 323);
            this.FileList.SortColumnOrder = System.Windows.Forms.SortOrder.None;
            this.FileList.Style = MetroFramework.MetroColorStyle.White;
            this.FileList.TabIndex = 1;
            this.FileList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.UseCustomBackColor = true;
            this.FileList.UseCustomForeColor = true;
            this.FileList.UseSelectable = true;
            this.FileList.View = System.Windows.Forms.View.Details;
            this.FileList.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.FolderTree);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.StatusStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "NAR Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem extractAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptModelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private FilesListView FileList;
        private System.Windows.Forms.ToolStripStatusLabel CurrentPath;
        private System.Windows.Forms.ToolStripStatusLabel SelectedItem;
    }
}

