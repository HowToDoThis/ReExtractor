using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexon.CSO;

namespace ReExtractor
{
    class FilesEventArgs : EventArgs
    {
        private string path;
        private IList<NexonArchiveFileEntry> file;

        public string Path
        {
            get { return path; }
        }

        public IList<NexonArchiveFileEntry> File
        {
            get { return file; }
        }

        public FilesEventArgs() : this (String.Empty, null)
        {

        }

        public FilesEventArgs(string Path, IList<NexonArchiveFileEntry> File)
        {
            path = Path;
            file = File;
        }
    }
}
