using Nexon.CSO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ReExtractor
{
    class FilesListView : ListView
    {
        private IContainer Components;
        private new ColumnHeader Name;
        private ColumnHeader LastModified;
        private new ColumnHeader Size;
        private ContextMenuStrip CMS;
        private ToolStripMenuItem Extract;
        private ToolStripMenuItem Verify;

        public event EventHandler<FilesEventArgs> ExtractFile;
        public event EventHandler<FilesEventArgs> VerifyFile;

        public string FullPath { get; set; }

        public int SortColumn
        {
            get
            {
                if (ListViewItemSorter is ColumnSort sort && sort.Column >= 0 && sort.Column < Columns.Count)
                {
                    return sort.Column;
                }
                return -1;
            }
        }

        public SortOrder SortColumnOrder
        {
            get
            {
                if (ListViewItemSorter is ColumnSort sort && sort.Column >= 0 && sort.Column < Columns.Count)
                {
                    return sort.Order;
                }
                return SortOrder.None;
            }
            set
            {
                if (ListViewItemSorter is ColumnSort sort)
                {
                    sort.Order = value;
                    Sort();
                }
            }
        }

        private sealed class ColumnSort : IComparer
        {
            private FilesListView FLV;
            public int Column = -1;
            public SortOrder Order;

            public ColumnSort(FilesListView listView)
            {
                FLV = listView;
            }

            public int Compare(object x, object y)
            {
                ListViewItem yItem = y as ListViewItem;

                if (!(x is ListViewItem xItem))
                {
                    if (yItem == null)
                    {
                        return 0;
                    }
                    return -1;
                }
                else
                {
                    if (yItem == null)
                    {
                        return 1;
                    }

                    if (this.Column < 0 || this.Order == SortOrder.None)
                    {
                        return 0;
                    }

                    if (this.Order != SortOrder.Ascending && this.Order != SortOrder.Descending)
                    {
                        return 0;
                    }

                    NexonArchiveFileEntry xFile = xItem.Tag as NexonArchiveFileEntry;
                    NexonArchiveFileEntry yFile = yItem.Tag as NexonArchiveFileEntry;
                    if (this.Column >= xItem.SubItems.Count && this.Column >= yItem.SubItems.Count)
                    {
                        return 0;
                    }

                    int value;
                    switch (this.Column)
                    {
                        case 1:
                            if (xFile != null && yFile != null)
                            {
                                value = DateTime.Compare(xFile.LastModifiedTime, yFile.LastModifiedTime);
                                goto IL_10F;
                            }
                            break;
                        case 2:
                            if (xFile != null && yFile != null)
                            {
                                value = xFile.Size.CompareTo(yFile.Size);
                                goto IL_10F;
                            }
                            break;
                    }

                    value = string.Compare(xItem.SubItems[this.Column].Text, yItem.SubItems[this.Column].Text, StringComparison.CurrentCultureIgnoreCase);

                IL_10F:
                    if (this.Order == SortOrder.Descending)
                    {
                        return -value;
                    }
                    return value;
                }
            }

        }

        public FilesListView()
        {
            InitializeComponent();
            ListViewItemSorter = new FilesListView.ColumnSort(this) { Column = -1, Order = SortOrder.None };
        }

        private void InitializeComponent()
        {
            Components = new Container();
            Name = new ColumnHeader();
            LastModified = new ColumnHeader();
            Size = new ColumnHeader();
            CMS = new ContextMenuStrip(Components);
            Extract = new ToolStripMenuItem();
            Verify = new ToolStripMenuItem();

            CMS.SuspendLayout();
            SuspendLayout();

            Name.Text = "Name";
            Name.Width = 150;
            LastModified.Text = "Last Modified";
            LastModified.Width = 150;
            Size.Text = "Size";
            Size.Width = 80;

            CMS.Items.AddRange(new ToolStripItem[] { Extract, Verify });
            CMS.Name = CMS.ToString();
            CMS.Size = new Size(119, 48);
            CMS.Opening += CMS_Opening;

            Extract.Name = "Extract";
            Extract.Size = new Size(118, 22);
            Extract.Text = "E&xtract";
            Extract.Click += Extract_Click;

            Verify.Name = "Verify";
            Verify.Size = new Size(118, 22);
            Verify.Text = "&Verify";
            Verify.Click += Verify_Click;

            Columns.AddRange(new ColumnHeader[] { Name, LastModified, Size });

            ContextMenuStrip = CMS;
            FullRowSelect = true;
            HideSelection = false;
            View = View.Details;
            ColumnClick += FilesListView_ColumnClick;

            CMS.ResumeLayout();
            ResumeLayout();
        }

        private void FilesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (ListViewItemSorter is ColumnSort sort)
            {
                if (sort.Column != e.Column)
                {
                    sort.Column = e.Column;
                    sort.Order = SortOrder.Ascending;
                }
                else
                {
                    switch (sort.Order)
                    {
                        case SortOrder.None:
                        case SortOrder.Descending:
                            sort.Order = SortOrder.Ascending;
                            break;
                        case SortOrder.Ascending:
                            sort.Order = SortOrder.Descending;
                            break;
                    }
                }
                SetSortIcon(sort.Column, sort.Order);
                Sort();
                return;
            }
            SetSortIcon(-1, SortOrder.None);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && Components != null)
                Components.Dispose();
            base.Dispose(disposing);
        }

        private void SetSortIcon(int columnIndex, SortOrder order)
        {
            IntPtr columnHeader = NativeMethods.SendMessage(Handle, 4127, IntPtr.Zero, IntPtr.Zero);
            for (int columnNumber = 0; columnNumber <= base.Columns.Count - 1; columnNumber++)
            {
                IntPtr columnPtr = new IntPtr(columnNumber);
                NativeMethods.LVCOLUMN lvColumn = default(NativeMethods.LVCOLUMN);
                lvColumn.mask = 4;
                NativeMethods.SendMessage(columnHeader, 4619, columnPtr, ref lvColumn);
                if (order != SortOrder.None && columnNumber == columnIndex)
                {
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            lvColumn.fmt &= -513;
                            lvColumn.fmt |= 1024;
                            break;
                        case SortOrder.Descending:
                            lvColumn.fmt &= -1025;
                            lvColumn.fmt |= 512;
                            break;
                    }
                }
                else
                {
                    lvColumn.fmt &= -1537;
                }
                NativeMethods.SendMessage(columnHeader, 4620, columnPtr, ref lvColumn);
            }
        }

        private void Verify_Click(object sender, EventArgs e)
        {
            if (SelectedIndices.Count > 0)
            {
                List<NexonArchiveFileEntry> files = new List<NexonArchiveFileEntry>();
                foreach (object obj in SelectedItems)
                {
                    ListViewItem item = (ListViewItem)obj;
                    if (item.Tag is NexonArchiveFileEntry file)
                        files.Add(file);
                }
                OnVerifyFolder(new FilesEventArgs(FullPath, files));
            }
        }

        private void Extract_Click(object sender, EventArgs e)
        {
            if (SelectedIndices.Count > 0)
            {
                List<NexonArchiveFileEntry> files = new List<NexonArchiveFileEntry>();
                foreach (object obj in SelectedItems)
                {
                    ListViewItem item = (ListViewItem)obj;
                    if (item.Tag is NexonArchiveFileEntry file)
                        files.Add(file);
                }
                OnExtractFolder(new FilesEventArgs(FullPath, files));
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            if (ListViewItemSorter is ColumnSort sort)
                SetSortIcon(sort.Column, sort.Order);
        }

        private static string GetHumanSize(long size)
        {
            if (size < 0L)
            {
                return string.Empty;
            }

            double temp = (double)size;
            if (temp <= 1024.0)
            {
                return temp.ToString("n0", NumberFormatInfo.CurrentInfo) + ((temp == 1.0) ? " byte" : " bytes");
            }

            temp /= 1024.0;
            if (temp <= 1024.0)
            {
                return temp.ToString("n0", NumberFormatInfo.CurrentInfo) + " KB";
            }

            temp /= 1024.0;
            if (temp > 1024.0)
            {
                return (temp / 1024.0).ToString("n2", NumberFormatInfo.CurrentInfo) + " GB";
            }

            return temp.ToString("n2", NumberFormatInfo.CurrentInfo) + " MB";
        }

        private void CMS_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedIndices.Count <= 0)
                e.Cancel = true;
        }

        protected void OnExtractFolder(FilesEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            ExtractFile?.Invoke(this, e);
        }

        protected void OnVerifyFolder(FilesEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            VerifyFile?.Invoke(this, e);
        }

        public ListViewItem AddFile(NexonArchiveFileEntry narFile)
        {
            if (narFile == null)
                throw new ArgumentNullException("NAR File");

            ListViewItem item = new ListViewItem(Path.GetFileName(narFile.Path))
            {
                Tag = narFile
            };
            item.SubItems.Add(narFile.LastModifiedTime.ToString(DateTimeFormatInfo.CurrentInfo));
            item.SubItems.Add(GetHumanSize(narFile.Size));
            Items.Add(item);
            return item;
        }
    }
}
