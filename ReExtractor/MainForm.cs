using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReExtractor.Properties;
using MetroFramework;
using MetroFramework.Forms;
using Nexon.CSO;

namespace ReExtractor
{
    public partial class MainForm : MetroForm
    {
        private NexonArchive Nar;
        private ExtractHelper ExHelper = new ExtractHelper();
        private Settings settings = new Settings();

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetTitle(string Name, bool modified)
        {
            if (String.IsNullOrEmpty(Name))
            {
                Text = String.Format(CultureInfo.CurrentUICulture, "NAR Extractor", new object[0]);
            }

            if (modified)
            {
                this.Text = String.Format(CultureInfo.CurrentUICulture, "NAR Extractor [{0}]*", new object[] { Name });
                return;
            }

            this.Text = String.Format(CultureInfo.CurrentUICulture, "NAR Extractor [{0}]", new object[] { Name });
        }

        private void SetTitle(string Name)
        {
            SetTitle(Name, false);
        }

        private void Open(string NarFile)
        {
            CloseArchive();

            try
            {
                Nar = new NexonArchive();
                Nar.Load(NarFile, false);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open file : " + NarFile, "Error");
                return;
            }

            SetTitle(NarFile);
            FolderTree.LoadArchive(Nar);
        }

        private void CloseArchive()
        {
            if (Nar != null)
            {
                FolderTree.Nodes.Clear();
                FileList.Items.Clear();
                Nar.Close();
                SetTitle(null);
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
                    Open(files[0]);
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
                return;
            }
            e.Effect = DragDropEffects.None;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseArchive();
        }

        private void FolderTree_ShowFolder(object sender, FilesEventArgs e)
        {
            CurrentPath.Text = e.Path;
            FileList.FullPath = e.Path;
            FileList.BeginUpdate();
            FileList.Items.Clear();
            if (e.File != null)
            {
                foreach (NexonArchiveFileEntry entry in e.File)
                    FileList.AddFile(entry);
            }
            FileList.EndUpdate();
            FileList_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FolderTree.SelectedNode == null)
                SelectedItem.Text = String.Empty;
            if (FileList.Items.Count >= 1)
                SelectedItem.Text = String.Format(NumberFormatInfo.CurrentInfo, "{0} item(s)", new object[] { FileList.Items.Count });
            if (FileList.SelectedIndices.Count > 0)
                SelectedItem.Text = String.Format(NumberFormatInfo.CurrentInfo, "{0} item(s) selected", new object[] { FileList.SelectedIndices.Count});
        }

        private void ExtractFiles(object sender, FilesEventArgs e)
        {
            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                ExHelper.DecryptModels = settings.DecryptModels;
                ExHelper.ExtractPath = SaveDialog.SelectedPath;

                using (Status status = new Status(new Predicate<NexonArchiveFileEntry>(ExHelper.Extract), e.File))
                {
                    status.Text = "Extracting files...";
                    status.DestinationPath = ExHelper.ExtractPath;

                    DialogResult dr = status.ShowDialog(this);

                    if (dr == DialogResult.Abort)
                        MessageBox.Show("An Error Occured While Extracting The Files...", "Error");
                    else if (dr == DialogResult.OK)
                        MessageBox.Show("All The Selected Files Have Been Extracted Successfully.", "Complete");
                }
            }
        }

        private static bool VerifyHelper(NexonArchiveFileEntry entry)
        {
            return entry.Verify();
        }

        private void VerifyFiles(object sender, FilesEventArgs e)
        {
            using (Status status = new Status(new Predicate<NexonArchiveFileEntry>(VerifyHelper), e.File))
            {
                status.Text = "Verifying files...";
                DialogResult dr = status.ShowDialog(this);
                if (dr == DialogResult.Abort)
                    MessageBox.Show("An Error Occured While Verifying The Files...", "Error");
                else if (dr == DialogResult.OK)
                    MessageBox.Show("All The Selected Files Have Been Verified Successfully.", "Complete");
            }
        }

        private void DecryptStrip_Click(object sender, EventArgs e)
        {
            settings.DecryptModels = DecryptStrip.Checked;
        }

        private void ExitStrip_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectAllStrip_Click(object sender, EventArgs e)
        {
            FileList.Focus();
            foreach (object obj in FileList.Items)
            {
                ListViewItem item = (ListViewItem)obj;
                item.Selected = true;
            }
        }

        private void ExtractStrip_Click(object sender, EventArgs e)
        {
            if (Nar != null && FolderTree.TopNode!= null)
            {
                List<NexonArchiveFileEntry> files = new List<NexonArchiveFileEntry>();
                FolderTreeView.GetFilesRecursive(FolderTree.TopNode, files);
                ExtractFiles(this, new FilesEventArgs(FolderTreeView.GetFullPath(FolderTree.TopNode), files));
            }
        }

        private void VerifyStrip_Click(object sender, EventArgs e)
        {
            if (Nar != null && FolderTree.TopNode != null)
            {
                List<NexonArchiveFileEntry> files = new List<NexonArchiveFileEntry>();
                FolderTreeView.GetFilesRecursive(FolderTree.TopNode, files);
                VerifyFiles(this, new FilesEventArgs(FolderTreeView.GetFullPath(FolderTree.TopNode), files));
            }
        }

        private void OpenStrip_Click(object sender, EventArgs e)
        {
            OpenDialogue();
        }

        private void OpenDialogue()
        {
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                Open(OpenDialog.FileName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrentPath.Text = String.Empty;
            SelectedItem.Text = String.Empty;
        }
    }
}
