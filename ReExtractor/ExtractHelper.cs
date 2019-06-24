using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nexon.CSO;

namespace ReExtractor
{
    class ExtractHelper
    {
        private string path;
        public string ExtractPath;
        public bool DecryptModels;
        private int Index = 0;

        public bool Extract(NexonArchiveFileEntry entry)
        {
            path = entry.Path;
            while (path[Index] == Path.DirectorySeparatorChar || path[Index] == Path.AltDirectorySeparatorChar)
                Index++;

            path = path.Substring(Index);
            path = Path.Combine(ExtractPath, path);

            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(path));
            if (!dir.Exists)
                dir.Create();

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                entry.Extract(fs);

                if (DecryptModels && String.Compare(Path.GetExtension(path), ".mdl", StringComparison.OrdinalIgnoreCase) == 0)
                    ModelHelper.DecryptModel(fs);
            }
            return true;
        }
    }
}
