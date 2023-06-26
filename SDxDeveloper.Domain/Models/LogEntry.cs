using System;

namespace SDxDeveloper.Domain.Models
{
    public readonly struct LogEntry
    {
        public string Type { get; }

        public string Module { get; }

        public int ProcessID { get; }

        public string Namespace { get; }

        public string MethodName { get; }

        public DateTime OccurredDate { get; }

        public ExceptionInfo ExceptionInfo { get; }

        public LogEntry(string type, string module, int processID, string @namespace, string methodName, DateTime occurredDate, ExceptionInfo exceptionInfo)
        {
            Type = type;
            Module = module;
            ProcessID = processID;
            Namespace = @namespace;
            MethodName = methodName;
            OccurredDate = occurredDate;
            ExceptionInfo = exceptionInfo;
        }
    }
}
