using System.Threading.Tasks;
using WorkflowEngine.Core.Models;

namespace WorkflowEngine.Core.Stores
{
    public interface IWorkflowStore
    {
        Task<Workflow> GetWorkflowByIdAsync(int workflowId);
    }
}
