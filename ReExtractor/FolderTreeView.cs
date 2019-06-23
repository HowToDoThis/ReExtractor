using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Nexon.CSO;

namespace ReExtractor
{
    class FolderTreeView : TreeView
    {
        private IContainer Components;
        private ContextMenuStrip cms;
        private ToolStripMenuItem extract;
        private ToolStripMenuItem verify;

        public event EventHandler<FilesEventArgs> ShowFolder;
        public event EventHandler<FilesEventArgs> ExtractFolder;
        public event EventHandler<FilesEventArgs> VerifyFolder;

        private sealed class TreeSort : IComparer
        {
            private FolderTreeView ftv;

            public TreeSort(FolderTreeView folderTreeView)
            {
                ftv = folderTreeView;
            }

            public int Compare(object a, object b)
            {
                TreeNode x = a as TreeNode;
                TreeNode y = b as TreeNode;

                if (x == null)
                {
                    if (y == null)
                    {
                        return 0;
                    }
                    return -1;
                }
                else
                {
                    if (y == null)
                    {
                        return 1;
                    }
                    return string.Compare(x.Text, y.Text, StringComparison.CurrentCultureIgnoreCase);
                }
            }
        }

        public FolderTreeView()
        {
            InitializeComponent();
            TreeViewNodeSorter = new FolderTreeView.TreeSort(this);
        }

        protected void OnShowFolder(FilesEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            ShowFolder?.Invoke(this, e);
        }

        protected void OnExtractFolder(FilesEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            ExtractFolder?.Invoke(this, e);
        }

        protected void OnVerifyFolder(FilesEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            VerifyFolder?.Invoke(this, e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && Components != null)
            {
                Components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Components = new Container();
            cms = new ContextMenuStrip(Components);
            extract = new ToolStripMenuItem();
            verify = new ToolStripMenuItem();
            cms.SuspendLayout();
            SuspendLayout();
            cms.Items.AddRange(new ToolStripItem[] { extract, verify });
            cms.Name = "CMS";
            cms.Size = new Size(119, 48);
            cms.Opening += Cms_Opening;
            extract.Name = "Extract";
            extract.Size = new Size(118, 22);
            extract.Text = "E&xtract";
            extract.Click += Extract_Click;
            verify.Name = "Verify";
            verify.Size = new Size(118, 22);
            verify.Text = "&Verify";
            verify.Click += Verify_Click;
            ContextMenuStrip = cms;
            HideSelection = false;
            LineColor = Color.Blue;
            AfterSelect += FolderTreeView_AfterSelect;
            MouseDown += FolderTreeView_MouseDown;
            cms.ResumeLayout();
            ResumeLayout();
        }

        private static TreeNode FindOrCreateNodePath(TreeNode rootNode, string path)
        {
            if (path.Length == 0)
            {
                return rootNode;
            }

            int startIndex = 0;
            while (path[startIndex] == '/' || path[startIndex] == '\\')
            {
                startIndex++;
            }

            int separatorIndex = path.IndexOfAny(new char[] { '/', '\\' }, startIndex);

            string name;
            if (separatorIndex >= 0)
            {
                name = path.Substring(startIndex, separatorIndex - startIndex);
            }
            else
            {
                name = path.Substring(startIndex);
            }

            TreeNode finalNode = null;
            foreach (object obj in rootNode.Nodes)
            {
                TreeNode node = (TreeNode)obj;
                if (string.Compare(node.Name, name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    finalNode = node;
                    break;
                }
            }

            if (finalNode == null)
            {
                finalNode = new TreeNode(name);
                finalNode.Name = name;
                rootNode.Nodes.Add(finalNode);
            }

            if (separatorIndex >= 0)
            {
                return FolderTreeView.FindOrCreateNodePath(finalNode, path.Substring(separatorIndex + 1));
            }

            return finalNode;
        }

        public void LoadArchive(NexonArchive narFile)
        {
            Nodes.Clear();

            if (narFile == null)
                return;

            TreeNode rootNode = new TreeNode("(NAR File)");
            foreach (NexonArchiveFileEntry entry in narFile.FileEntries)
            {
                TreeNode node = FolderTreeView.FindOrCreateNodePath(rootNode, Path.GetDirectoryName(entry.Path));

                if (!(node.Tag is IList<NexonArchiveFileEntry> nodeList))
                {
                    nodeList = new List<NexonArchiveFileEntry>();
                    node.Tag = nodeList;
                }
                nodeList.Add(entry);
            }
            rootNode.Expand();
            Nodes.Add(rootNode);
            SelectedNode = rootNode;
        }

        public static IList<NexonArchiveFileEntry> GetFilesRecursive(TreeNode node, IList<NexonArchiveFileEntry> files)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (files == null)
            {
                throw new ArgumentNullException("files");
            }

            if (node.Tag is IList<NexonArchiveFileEntry> directoryFiles)
            {
                foreach (NexonArchiveFileEntry file in directoryFiles)
                {
                    files.Add(file);
                }
            }

            foreach (object obj in node.Nodes)
            {
                TreeNode childNode = (TreeNode)obj;
                FolderTreeView.GetFilesRecursive(childNode, files);
            }

            return files;
        }

        public static string GetFullPath(TreeNode node)
        {
            if (node == null || node.Parent == null)
                return String.Empty;
            if (node.Parent != null && node.Parent.Parent != null)
                return FolderTreeView.GetFullPath(node.Parent) + "/" + node.Text;

            return node.Text;
        }

        private void FolderTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                SelectedNode = GetNodeAt(e.Location);
                
                if (SelectedNode == null)
                {
                    OnShowFolder(new FilesEventArgs());
                }
            }
        }

        private void Verify_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                List<NexonArchiveFileEntry> file = new List<NexonArchiveFileEntry>();
                FolderTreeView.GetFilesRecursive(base.SelectedNode, file);
                OnVerifyFolder(new FilesEventArgs(FolderTreeView.GetFullPath(base.SelectedNode), file));
            }

        }

        private void Extract_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                List<NexonArchiveFileEntry> file = new List<NexonArchiveFileEntry>();
                FolderTreeView.GetFilesRecursive(base.SelectedNode, file);
                OnExtractFolder(new FilesEventArgs(FolderTreeView.GetFullPath(base.SelectedNode), file));
            }
        }

        private void Cms_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedNode == null)
                e.Cancel = true;
        }

        private void FolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnShowFolder(new FilesEventArgs(FolderTreeView.GetFullPath(e.Node), e.Node.Tag as List<NexonArchiveFileEntry>));
        }
    }
}
