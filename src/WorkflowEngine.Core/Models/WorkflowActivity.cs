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

namespace WorkflowEngine.Core.Models
{
    public class WorkflowActivity
    {
        /// <summary>
        /// Identitifire
        /// </summary>
        public int WorkflowActivityId { get; set; }

        /// <summary>
        /// name in arabic
        /// </summary>
        public string NameAr { get; set; }

        /// <summary>
        /// name in english
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// is complete activity
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// is start activity, and if so then,
        /// this it will be the first step int tho wrokflow
        /// </summary>
        public bool IsStart { get; set; }

        public Workflow Workflow { get; set; }
    }
}
