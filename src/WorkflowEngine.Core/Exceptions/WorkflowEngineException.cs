using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine.Core.Exceptions
{
    public class WorkflowEngineException : Exception
    {
        public WorkflowEngineException(string message) : base(message)
        {

        }
    }
}
