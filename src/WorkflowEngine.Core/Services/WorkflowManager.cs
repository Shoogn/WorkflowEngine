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
using WorkflowEngine.Core.Exceptions;
using WorkflowEngine.Core.Models;
using WorkflowEngine.Core.Results;
using WorkflowEngine.Core.Stores;
using WorkflowEngine.Core.Validation;

namespace WorkflowEngine.Core.Services
{
    public class WorkflowManager
    {
        private readonly IWorkflowActivityStepStore _workflowActivityStepStore;
        private WorkflowContextValidation _validator;
        public WorkflowManager(IWorkflowActivityStepStore workflowActivityStepStore)
        {
            _workflowActivityStepStore = workflowActivityStepStore;
            _validator = new WorkflowContextValidation();
        }

        public virtual async Task<WorkflowResult> Execute(WorkflowContext workflowContext)
        {
            // Here first I have to validate the WorkflowContext object
            var validationRsult = _validator.ValidateWorkflowContext(workflowContext);
            if (!validationRsult.IsValid)
                return new WorkflowResult { IsValid = false };

            var query = await _workflowActivityStepStore.GetWorkflowActivityStepByIdAsync(workflowContext.CurrentActivityId);

            if (query == null)
                throw new WorkflowEngineException("activity is not found");

            // here I have to perform the action
            var actionToApplyFromStore = query.WorkflowAction;
            if (actionToApplyFromStore.WorkflowActionId != workflowContext.ActionId)
                throw new WorkflowEngineException("this action is not applicable to this step");




            return new WorkflowResult
            {
                WorkflowActivityStep = query,
                WorkflowContext = workflowContext,
                IsValid = true
            };
        }

        public IList<WorkflowAction> GetAllActionsForActivity(int workflowActivityId)
        {
            var workflowActions = (from m in _workflowActivityStepStore.FindAllWorkflowActivitySteps()
                                   where m.NextWorkflowActivity.WorkflowActivityId == workflowActivityId
                                   group m by new
                                   {
                                       WorkflowActionId = m.WorkflowAction.WorkflowActionId,
                                       NameAr = m.WorkflowAction.NameAr,
                                       NameEn = m.WorkflowAction.NameEn
                                   } into g select new WorkflowAction
                                   {
                                       WorkflowActionId = g.Key.WorkflowActionId,
                                       NameEn = g.Key.NameEn,
                                       NameAr = g.Key.NameAr,
                                   }).ToList();
            return workflowActions;
        }
    }
}
