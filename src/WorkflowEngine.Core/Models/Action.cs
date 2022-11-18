namespace WorkflowEngine.Core.Models
{
    /// <summary>
    /// Action object
    /// </summary>
    public sealed class Action
    {
        /// <summary>
        /// Identitifire
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// name in arabic
        /// </summary>
        public string NameAr { get; set; }

        /// <summary>
        /// name in english
        /// </summary>
        public string NameEn { get; set; }
        
    }
}
