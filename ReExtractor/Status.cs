using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexon.CSO;
using MetroFramework;
using MetroFramework.Forms;
using System.IO;

namespace ReExtractor
{
    public partial class Status : MetroForm
    {
        private Predicate<NexonArchiveFileEntry> PredicateEntry;
        private ICollection<NexonArchiveFileEntry> CollectionEntry;
        private ProgressUpdate pu = new ProgressUpdate();

        public string DestinationPath { get; set; }

        private sealed class ProgressUpdate
        {
            public long CurrentFileSize;
            public long TotalFileSize;
        }

        public Status(Predicate<NexonArchiveFileEntry> predicate, ICollection<NexonArchiveFileEntry> entries)
        {
            PredicateEntry = predicate ?? throw new ArgumentNullException("predicate"); ;
            CollectionEntry = entries ?? throw new ArgumentNullException("entries");

            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            Worker.RunWorkerAsync();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
                Bar.ProgressBarStyle = ProgressBarStyle.Marquee;
                return;
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitProgressWork(object state)
        {
            Bar.ProgressBarStyle = ProgressBarStyle.Continuous;
            Spinner.Spinning = true;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (CollectionEntry)
            {
                foreach (NexonArchiveFileEntry entry in CollectionEntry)
                    pu.TotalFileSize += entry.Size;

                if (Worker.CancellationPending)
                    e.Cancel = true;
                else
                {
                    Delegate method = new Action<object>(InitProgressWork);
                    object[] args = new object[1];
                    Invoke(method, args);
                    if (Worker.CancellationPending)
                        e.Cancel = true;
                    else
                    {
                        foreach (NexonArchiveFileEntry entry2 in CollectionEntry)
                        {
                            if (!PredicateEntry(entry2))
                                throw new ApplicationException("Task sent an abort code.");
                            if (Worker.CancellationPending)
                                e.Cancel = true;
                            pu.CurrentFileSize += entry2.Size;
                            Worker.ReportProgress(0, pu);
                        }
                    }
                }
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ProgressUpdate pu2)
            {
                int width = Bar.ClientSize.Width;
                Bar.Maximum = width;
                Bar.Value = Convert.ToInt32(pu2.CurrentFileSize * (long)width / pu2.TotalFileSize);

                int width2 = Spinner.ClientSize.Width;
                Spinner.Maximum = width2;
                Spinner.Value = Convert.ToInt32(pu2.CurrentFileSize * (long)width / pu2.TotalFileSize);
                return;
            }

            string path = e.UserState as string;

            if (!String.IsNullOrEmpty(path))
            {
                path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                int Index = 0;

                while (path[Index] == Path.DirectorySeparatorChar)
                    Index++;

                path = path.Substring(Index);
                SrcData.Text = path;

                if (DestData != null)
                    DestData.Text = Path.Combine(DestinationPath, path);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                DialogResult = DialogResult.Abort;
            else if (e.Cancelled)
                DialogResult = DialogResult.Cancel;
            else
            {
                Bar.Value = Bar.Maximum;
                Spinner.Value = Spinner.Maximum;
                DialogResult = DialogResult.OK;
            }
            Close();
        }
    }
}
