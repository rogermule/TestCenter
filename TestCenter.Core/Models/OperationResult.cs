using System;
using System.Collections.Generic;
using System.Text;

namespace TestCenter.Core.Models
{
    public class OperationResult
    {
        public OperationStatus Status { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }

    public enum OperationStatus
    {
        Success,
        Exception,
        Ok
    }
}
