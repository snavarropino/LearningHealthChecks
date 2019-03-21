namespace HealthChecksUI.Model
{
    public class WebHooksConfiguration
    {
        public Webhook[] Webhooks { get; set; }
    }

    public class Webhook
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Payload { get; set; }
        public string RestoredPayload { get; set; }
    }
}