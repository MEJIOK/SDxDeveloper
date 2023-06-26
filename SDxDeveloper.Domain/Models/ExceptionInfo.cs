namespace SDxDeveloper.Domain.Models
{
    public readonly struct ExceptionInfo
    {
        public string Namespace { get; }

        public string ExceptionName { get; }

        public string Message { get; }

        public ExceptionInfo(string @namespace, string exceptionName, string message)
        {
            Namespace = @namespace;
            ExceptionName = exceptionName;
            Message = message;
        }
    }
}
