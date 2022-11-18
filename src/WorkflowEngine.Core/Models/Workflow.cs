namespace WorkflowEngine.Core.Models
{
    /// <summary>
    /// Workflow object
    /// </summary>
    public sealed class Workflow
    {
        /// <summary>
        /// Identitifire
        /// </summary>
        public int WorkflowId { get; set; }

        /// <summary>
        /// name in arabic
        /// </summary>
        public string NameAr { get; set; }

        /// <summary>
        /// name in english
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// is active or not
        /// by default is true
        /// if is not active (false) the workflow can not procceed any flow
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
