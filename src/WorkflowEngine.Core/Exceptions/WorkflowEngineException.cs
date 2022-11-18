using System;

namespace WorkflowEngine.Core.Exceptions
{
    public class WorkflowEngineException : Exception
    {
        public WorkflowEngineException(string message) : base(message)
        {

        }
        public WorkflowEngineException(string message, Exception innerException) 
            : base(message, innerException)
        {

        }
    }
}
