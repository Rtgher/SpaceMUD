﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Interfaces;

namespace SpaceMUD.Common.Logging
{
    public class Logger : ILog
    {
        private StringBuilder _logBuffer;
        private readonly int MaxCharCount;
        private string time => DateTime.Now.ToString("g");
        private string _logSavePath;
        public StringBuilder LogBuffer => _logBuffer = _logBuffer ?? new StringBuilder();

        public Logger(string logSavePath, int maxCharCount= 5000)
        {
            _logSavePath = logSavePath;
            MaxCharCount = maxCharCount;
        }

        public void LogError(string message, Exception exception)
        {
            string log = $"[{time}]-[ERROR]:{message}\r\n[StackTrace]: {exception.StackTrace}";
            Console.WriteLine(log);
            _logBuffer.AppendLine(log);
            if (_logBuffer.Length >= MaxCharCount) PurgeLog();
        }

        public void LogInfo(string info)
        {
            string log = $"[{time}]-[Info]: {info}";
            Console.WriteLine(log);
            _logBuffer.AppendLine(log);
            if (_logBuffer.Length >= MaxCharCount) PurgeLog();
        }

        public void LogWarning(string warningInfo, Exception caughtException = null)
        {
            string log = $"[{time}]-[Warning]:{warningInfo}\r\n[StackTrace]: {caughtException?.StackTrace?? "No Stack trace available."}";
            Console.WriteLine(log);
            _logBuffer.AppendLine(log);
            if (_logBuffer.Length >= MaxCharCount) PurgeLog();
        }

        public void PurgeLog()
        {
            using (StreamWriter file = new StreamWriter(_logSavePath + "/gamelog.txt", append: true)) file.WriteLine(LogBuffer.ToString());
            _logBuffer.Clear();
        }
    }
}
