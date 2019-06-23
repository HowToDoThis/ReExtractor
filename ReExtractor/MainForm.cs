using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using Nexon.CSO;

namespace ReExtractor
{
    public partial class MainForm : MetroForm
    {
        private NexonArchive Nar;

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
                MetroMessageBox.Show(this, "Could not open file : " + NarFile, "Error");
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
                string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files != null && files.Length > 0)
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
            FileList.Items.Clear();
            if (e.File != null)
            {
                foreach (NexonArchiveFileEntry entry in e.File)
                    FileList.AddFile(entry);
            }
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
    }
}
