using Agenda.Domain;
using Agenda.Infra.Data;
using Agenda.Infra.Dto;
using Agenda.Infra.Model;

namespace Agenda.Infra.Repository
{
    public class ContatoRepository : IContato
    {
        private readonly DataContext _db;

        public ContatoRepository(DataContext db)
        {
            _db = db;
        }

        public List<Contato> GetAllContacts()
        {
            var teste = _db.Contatos.ToList();
            return teste;
        }

        public Contato GetContactById(Guid id)
        {
            return _db.Contatos.FirstOrDefault(x => x.Id.Equals(id))!;
        }

        public void AddContact(ContactRequest contact)
        {
            try
            {
                _db.Add(new Contato
                {
                    Id = Guid.NewGuid(),
                    Name = contact.Name,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    WhatsappNumber = contact.WhatsappNumber,

                });
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateContact(Guid id, ContactRequest contact)
        {
            try
            {
                var contato = _db.Contatos.FirstOrDefault(x => x.Id.Equals(id));
                if (contato == null)
                {
                    throw new Exception("Contato não encontrato!, Não foi possivel atualizar");
                }
                else
                {
                    contato.Name = contact.Name;
                    contato.Email = contact.Email;
                    contato.PhoneNumber = contact.PhoneNumber;
                    contato.WhatsappNumber = contact.WhatsappNumber;

                    _db.Contatos.Update(contato);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteContact(Guid id)
        {
            try
            {
                var contato = _db.Contatos.FirstOrDefault(x => x.Id.Equals(id));
                if (contato == null)
                {
                    throw new Exception("Contato não encontrato!, Não foi possivel remover");
                }
                else
                {
                    _db.Contatos.Remove(contato);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
