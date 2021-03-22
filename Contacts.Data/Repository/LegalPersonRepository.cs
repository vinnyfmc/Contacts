using Contacts.Domain.Domains;
using Contacts.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace Contacts.Data
{
    public class LegalPersonRepository : ILegalPersonRepository
    {
        public IEnumerable<LegalPerson> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public LegalPerson GetById(long Id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(LegalPerson legalPerson)
        {
            throw new System.NotImplementedException();
        }
    }
}
