using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnesTechSecureAccessGuard.Core.CustomNLog
{
    public interface INLogLogger
    {
        void Log(LogLevel level, string message);
        void Log(LogLevel level, Exception exception, string message);
        void Trace(string message);
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Error(Exception exception, string message);
        void Fatal(string message);
        void Fatal(Exception exception, string message);
    }
}
