namespace WorkflowEngine.Core.Models
{
    public class ActivityStep
    {
        public int ActivityStepId { get; set; }
        public Activity Activity { get; set; }
        public Action Action { get; set; }
        public Activity NextActivity { get; set; }

        public bool WithSendEmail { get; set; }
        public bool WithSendNotification { get; set; }
        public bool RequiredNotes { get; set; }
    }
}
