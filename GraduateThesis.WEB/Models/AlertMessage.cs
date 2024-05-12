namespace GraduateThesis.WEB.Models
{
    public class AlertMessage
    {
        public List<string> MessageList { get; set; }
        public AlertType AlertType { get; set; }
    }

    public enum AlertType
    {
        danger,
        warning,
        success
    }
}
