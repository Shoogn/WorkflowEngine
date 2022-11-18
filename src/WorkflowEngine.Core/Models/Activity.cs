namespace WorkflowEngine.Core.Models
{
    public class Activity
    {
        /// <summary>
        /// Identitifire
        /// </summary>
        public int ActivityId { get; set; }

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
