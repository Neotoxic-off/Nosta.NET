using System;
using System.IO;

namespace Nosta.NET
{
    public class Logger
    {
        public enum Types
        {
            Warning,
            Error,
            Success,
            Information
        };

        private Dictionary<Types, string> text { get; set; }

        public Logger()
        {
            text = new Dictionary<Types, string>()
            {
                { Types.Warning, "WARN" },
                { Types.Error, "FAIL" },
                { Types.Success, "DONE" },
                { Types.Information, "INFO" },
            };
        }

        public void Log(Types log_type, string message)
        {
            Console.WriteLine($"[ {text[log_type]} ] {message}");
        }
    }
}
