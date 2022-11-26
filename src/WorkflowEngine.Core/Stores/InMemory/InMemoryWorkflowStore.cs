/*
**  Copyright 2022 Mohammed Ahmed Hussien babiker

**  Licensed under the Apache License, Version 2.0 (the "License");
**  you may not use this file except in compliance with the License.
**  You may obtain a copy of the License at

**  http://www.apache.org/licenses/LICENSE-2.0
**  Unless required by applicable law or agreed to in writing, software
**  distributed under the License is distributed on an "AS IS" BASIS,
**  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
**  See the License for the specific language governing permissions and
** limitations under the License.
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowEngine.Core.Models;

namespace WorkflowEngine.Core.Stores.InMemory
{
    public class InMemoryWorkflowStore : IWorkflowStore
    {
        private readonly IEnumerable<Workflow> _workflow;
        public InMemoryWorkflowStore()
        {
            _workflow = new List<Workflow>
            {
                new Workflow { WorkflowId = 1, IsActive = true, NameEn = "Test Workflow 1#" },
                new Workflow { WorkflowId = 2, IsActive = false, NameEn = "Test Workflow 2#" },
                new Workflow { WorkflowId = 3, IsActive = true, NameEn = "Test Workflow 3#" }
            };
        }

        //public InMemoryWorkflowStore(IEnumerable<Workflow> workflows)
        //{
        //    if (_workflow == null || !_workflow.Any())
        //        throw new WorkflowEngineException("work flow store can't be null or empty");
        //    _workflow = workflows;
        //}

        public Task<Workflow> GetWorkflowByIdAsync(int workflowId)
        {
            var query = (from workflow in _workflow
                         where workflow.WorkflowId == workflowId
                         select workflow);

            return Task.FromResult(query.SingleOrDefault());
        }

        public bool IsWorkflowActive(int workflowId)
        {
            var query = (from workflow in _workflow
                         where workflow.WorkflowId == workflowId
                         select workflow).SingleOrDefault();

            if (query.IsActive)
                return true;
            else
                return false;
        }
    }
}
