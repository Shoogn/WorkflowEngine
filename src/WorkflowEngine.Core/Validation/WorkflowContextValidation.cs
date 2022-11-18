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

using WorkflowEngine.Core.Results;

namespace WorkflowEngine.Core.Validation
{
    public  class WorkflowContextValidation
    {
        public  WorkflowResult ValidateWorkflowContext(WorkflowContext workflowContext)
        {
            if (workflowContext == null)
                return new WorkflowResult { IsValid = false };

            if (workflowContext.CurrentActivityId == 0 ||
                workflowContext.CurrentActivityId < 0 || workflowContext.ActionId == 0 ||
                workflowContext.ActionId < 0)
                return new WorkflowResult { IsValid = false };

            else
            {
                WorkflowResult result = new WorkflowResult { IsValid = true };
                return result;
            }


        }
    }
}
