using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Exceptions;
using WorkflowEngine.Core.Models;

namespace WorkflowEngine.Core.Stores.InMemory
{
    public class InMemoryWorkflowStore : IWorkflowStore
    {
        private readonly IEnumerable<Workflow> _workflow;

        public InMemoryWorkflowStore(IEnumerable<Workflow> workflows)
        {
            if (_workflow == null || !_workflow.Any())
                throw new WorkflowEngineException("work flow store can't be null or empty");
            _workflow = workflows;
        }

        public Task<Workflow> GetWorkflowByIdAsync(int workflowId)
        {
            throw new NotImplementedException();
        }
    }
}
