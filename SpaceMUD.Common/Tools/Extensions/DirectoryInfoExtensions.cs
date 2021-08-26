using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Tools.Extensions
{
    public static class DirectoryInfoExtensions
    {
        public static DirectoryInfo CreateIfNotExist(this DirectoryInfo self)
        {
            if (!self.Exists) self.Create();
            return self;
        }

        public static FileInfo CreateIfNotExist(this FileInfo self)
        {
            if (!self.Exists) self.Create();
            return self;
        }

        public static FileInfo GetOrCreateFileByName(this DirectoryInfo self, string name)
        {
            return new FileInfo($"{self.FullName}\\{name}").CreateIfNotExist();
        }
    }
}
