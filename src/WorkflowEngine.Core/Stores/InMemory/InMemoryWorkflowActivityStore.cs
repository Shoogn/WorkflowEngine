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
using System.Threading.Tasks;
using WorkflowEngine.Core.Models;

namespace WorkflowEngine.Core.Stores.InMemory
{
    public class InMemoryWorkflowActivityStore : IWorkflowActivityStore
    {
        private readonly Dictionary<int, WorkflowActivity> _workflowActivity = new Dictionary<int, WorkflowActivity>();

        public void Add(WorkflowActivity activity)
        {
            if (_workflowActivity.ContainsKey(activity.WorkflowActivityId))
                _workflowActivity[activity.WorkflowActivityId] = activity;
            else
                _workflowActivity.Add(activity.WorkflowActivityId, activity);
        }

        public void Add(IEnumerable<WorkflowActivity> workflowActivities)
        {
            foreach (var wactivity in workflowActivities)
                Add(wactivity);
        }

        public Task<WorkflowActivity> GetActivityByIdAsync(int workflowActivityId)
        {
            if (_workflowActivity.ContainsKey(workflowActivityId))
                return Task.FromResult(_workflowActivity[workflowActivityId]);
            else
                return null;
        }
    }
}
