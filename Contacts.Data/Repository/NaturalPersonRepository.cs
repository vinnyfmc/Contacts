using Contacts.Domain;
using Contacts.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace Contacts.Data
{
    public class NaturalPersonRepository : INaturalPersonRepository
    {
        public IEnumerable<NaturalPerson> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public NaturalPerson GetById(long Id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(NaturalPerson naturalPerson)
        {
            throw new System.NotImplementedException();
        }
    }
}
