namespace Agenda.Infra.Model
{
    public class Contato
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? WhatsappNumber { get; set; }
    }
}
