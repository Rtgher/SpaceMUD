using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Interfaces
{
    /// <summary>
    /// A basic logging interface to handle logs.
    /// </summary>
    public interface ILog : IDisposable
    {
        void LogInfo(string info);
        void LogWarning(string info, Exception caughtException = null);
        void LogError(string message, Exception exception);

        /// <summary>
        /// A Log Buffer to hold the contents of the log.
        /// </summary>
        StringBuilder LogBuffer { get; }
        /// <summary>
        /// Purge log buffer, hopefully saving a file.log.
        /// </summary>
        void PurgeLog();
    }
}
