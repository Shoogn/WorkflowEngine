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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowEngine.Core.Models;

namespace WorkflowEngine.Core.Stores.InMemory
{
    public class InMemoryWorkflowActionStore : IWorkflowActionStore
    {
        private readonly Dictionary<int, WorkflowAction> _workflowAction = new Dictionary<int, WorkflowAction>();

        public void Add(WorkflowAction action)
        {
           if(_workflowAction.ContainsKey(action.WorkflowActionId))
                _workflowAction[action.WorkflowActionId] = action;
           else
                _workflowAction.Add(action.WorkflowActionId, action);
        }

        public void Add(IEnumerable<WorkflowAction> workflowActions)
        {
           foreach(var wa in workflowActions)
                Add(wa);
        }

        public WorkflowAction GetById(int actionId)
        {
            if (_workflowAction.ContainsKey(actionId))
                return _workflowAction[actionId];
            else
                return null;
        }
    }
}
