using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Tools
{
    /// <summary>
    /// A helper static class for directory information.
    /// </summary>
    public static class DirectoryHelper
    {
        public static DirectoryInfo GetInstalationDirectoryRoot()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            DirectoryInfo directory = new DirectoryInfo(location);

            return directory.Parent;
        }
    }
}
