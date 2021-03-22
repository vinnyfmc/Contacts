using Contacts.Domain.Domains;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces.Repository
{
    public interface ILegalPersonRepository
    {
        LegalPerson GetById(long Id);
        IEnumerable<LegalPerson> GetAll();
        void Save(LegalPerson legalPerson);
    }
}
