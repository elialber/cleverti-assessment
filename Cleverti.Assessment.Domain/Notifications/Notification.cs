namespace Cleverti.Assessment.Domain.Notifications
{
    public class Notification
    {
        public string Field { get; }
        public string Message { get; }
        public string StackTrace { get; set; }

        public Notification(string field, string message)
        {
            Field = field;
            Message = message;
        }

        public Notification(string field, string message, string stackTrace)
        {
            Field = field;
            Message = message;
            StackTrace = stackTrace;
        }
    }
}
