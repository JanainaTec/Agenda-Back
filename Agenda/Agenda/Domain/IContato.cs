using Agenda.Infra.Dto;
using Agenda.Infra.Model;

namespace Agenda.Domain
{
    public interface IContato
    {
        List<Contato> GetAllContacts();

        Contato GetContactById(Guid id);

        void AddContact(ContactRequest contact);

        void UpdateContact(Guid id, ContactRequest contact);

        void DeleteContact(Guid id);
    }
}
