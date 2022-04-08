using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDotNet.CrossCutting.Contracts.Services
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
