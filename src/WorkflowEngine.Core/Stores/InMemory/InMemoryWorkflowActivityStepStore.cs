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
    public class InMemoryWorkflowActivityStepStore : IWorkflowActivityStepStore
    {
        private readonly Dictionary<int, WorkflowActivityStep> _workflowActivityStep = new
            Dictionary<int, WorkflowActivityStep>();

        public IQueryable<WorkflowActivityStep> FindAllWorkflowActivitySteps()
        {
            List<WorkflowActivityStep> ls = new List<WorkflowActivityStep>();
            if (_workflowActivityStep.Any())
            {
                foreach(var item in _workflowActivityStep)
                {
                    ls.Add(new WorkflowActivityStep
                    {
                        NextWorkflowActivity = item.Value.NextWorkflowActivity,
                        RequiredNotes = item.Value.RequiredNotes,
                        WithSendEmail = item.Value.WithSendEmail,
                        WithSendNotification = item.Value.WithSendNotification,
                        WorkflowAction = item.Value.WorkflowAction,
                        WorkflowActivity = item.Value.WorkflowActivity,
                        WorkflowActivityStepId = item.Key
                    });
                }

                return ls.AsQueryable();
            }
            else
            {
                return ls.AsQueryable();
            }
        }

        public Task<WorkflowActivityStep> GetWorkflowActivityStepByIdAsync(int workflowActivityStepId)
        {
            if (_workflowActivityStep.ContainsKey(workflowActivityStepId))
                return Task.FromResult(_workflowActivityStep[workflowActivityStepId]);
            else
                return null;
        }

        public void Add(WorkflowActivityStep workflowActivityStep)
        {
            if (_workflowActivityStep.ContainsKey(workflowActivityStep.WorkflowActivityStepId))
                _workflowActivityStep[workflowActivityStep.WorkflowActivityStepId] = workflowActivityStep;
            else
                _workflowActivityStep.Add(workflowActivityStep.WorkflowActivityStepId, workflowActivityStep);
        }

        public void Add(IEnumerable<WorkflowActivityStep> workflowActivitySteps)
        {
            foreach (var was in workflowActivitySteps)
                Add(was);
        }

    }
}
