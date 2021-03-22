using Contacts.Domain.Domains;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces.Repository
{
    public interface ILegalPersonRepository
    {
        LegalPerson GetById(long id);
        IEnumerable<LegalPerson> GetAll();
        IEnumerable<LegalPerson> GetByCNPJ(string cnpj);
        void Save(LegalPerson legalPerson);
    }
}
